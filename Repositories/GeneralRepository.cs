using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using USFH.Database;
using USFH.Models;
using USFH.Libs;
using USFH.DTOs;
using System.Text.Json;

namespace USFH.Repositories
{
    public interface IGeneralRepository
    {
        Task<List<Slide>> GetSlides();
        Task<List<ProductCategory>> GetCategories();
        Task<List<ProductCategory>> GetMainCategories();
        Task<List<Product>> GetNewProducts();
        Task<List<Blog>> GetNewBlogs();
        Task<PaginationDTO<List<Blog>>> GetBlogs(string search, int page);
        Task<Blog> GetBlogBySlug(string slug);
        Task<List<Product>> GetSellingProducts();
        Task<List<Banner>> GetBanners();
        Task<PaginationDTO<List<Product>>> GetProducts(string category, int page);
        Task<Product> GetProductBySlug(string slug);
        Task<List<Product>> GetProductByCategory(string category);
        Task<AboutUs> GetAboutUs();
        Task<ContactUs> GetContactUs();
        Task<bool> SendMessage(Message message);
        Task<PaginationDTO<List<Product>>> SearchedProduct(string searchKey, int page);
        Task<ShoppingDTO> GetShoppingItems();
        Task<ShoppingDTO> SetShoppingitem(int id);
        Task<ShoppingDTO> RemoveShoppingItem(int id);
        Task<ProductCategory> GetProductCategoryBySlug(string slug);
        Task<Dictionary<string,string>> GetSettings();

        Task<Order> AddOrder(Order order);
        void ProductSellingCount(List<Product> products);
    }
    public class GeneralRepository : IGeneralRepository
    {
        private readonly DataContext _db;
        private readonly IMyCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GeneralRepository(DataContext db, IMyCache cache,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AboutUs> GetAboutUs()
        {
            return (await _db.AboutUs!.AsNoTracking().FirstOrDefaultAsync())!;
        }

        public async Task<List<Banner>> GetBanners()
        {
            bool result = _cache.TryGetValue("Banners", out List<Banner> banners);
            if (!result)
            {
                banners = await _db.Banners!.AsNoTracking().Where(x => x.Status == true).OrderBy(x => x.Order).Take(3).ToListAsync();
                _cache.Set("Banners", banners);
            }
            return banners;
        }

        public async Task<Blog> GetBlogBySlug(string slug)
        {
            return (await _db.Blogs!.AsNoTracking().FirstOrDefaultAsync(x => x.Slug == slug))!;
        }

        public async Task<PaginationDTO<List<Blog>>> GetBlogs(string search, int page)
        {
            List<Blog> blogs = await _db.Blogs!.AsNoTracking().Where(x => (x.Title!.Contains(search ?? String.Empty) || x.SubTitle!.Contains(search ?? String.Empty)) && x.Status==true)
            .OrderByDescending(x => x.CreatedDate).Skip(page * 12).Take(12).ToListAsync();
            int count = await _db.Blogs!.AsNoTracking().Where(x => (x.Title!.Contains(search ?? String.Empty) || x.SubTitle!.Contains(search ?? String.Empty)) && x.Status == true)
            .OrderByDescending(x => x.CreatedDate).CountAsync();
            PaginationDTO<List<Blog>> result = Pagination<List<Blog>>.PaginationMethod(page, 12, count);
            result.Object = blogs;
            return result;
        }

        public async Task<List<ProductCategory>> GetCategories()
        {
            bool result = _cache.TryGetValue("ProductCategories", out List<ProductCategory> categories);
            if (!result)
            {
                categories = await _db.ProductCategories!.AsNoTracking().Include(x => x.Products).Where(x => x.Status == true).OrderBy(x => x.CreatedDate).ToListAsync();
                _cache.Set("ProductCategories", categories);
            }
            return categories;
        }

        public async Task<ContactUs> GetContactUs()
        {
            return (await _db.ContactUs!.FirstOrDefaultAsync())!;
        }

        public async Task<List<Blog>> GetNewBlogs()
        {
            bool result = _cache.TryGetValue("NewBlogs", out List<Blog> blogs);
            if (!result)
            {
                blogs = await _db.Blogs!.Where(x => x.Status).AsNoTracking().OrderByDescending(x => x.CreatedDate).ToListAsync();
                _cache.Set("NewBlogs", blogs);
            }
            return blogs;
        }

        public async Task<List<Product>> GetNewProducts()
        {
            bool result = _cache.TryGetValue("NewProducts", out List<Product> products);
            if (!result)
            {
                products = (await _db.Products!.AsNoTracking().Where(x => x.Status == true).Include(x => x.ProductImages).OrderByDescending(x => x.CreatedDate).Take(8).ToListAsync()) ?? new();
                _cache.Set("NewProducts", products);
            }
            return products;
        }

        public async Task<List<Product>> GetProductByCategory(string category)
        {
            return (await _db.Products!.AsNoTracking().Include(x => x.ProductCategory).Where(x => x.ProductCategory!.Slug == category).Include(x => x.ProductCategory).ToListAsync());
        }

        public async Task<Product> GetProductBySlug(string slug)
        {
            return (await _db.Products!.AsNoTracking().Include(x => x.ProductImages).Include(x => x.ProductCategory).FirstOrDefaultAsync(x => x.Slug == slug))!;
        }

        public async Task<PaginationDTO<List<Product>>> GetProducts(string category, int page)
        {
            List<Product> products = await _db.Products!.AsNoTracking().Include(x => x.ProductCategory).Where(x => (x.ProductCategory!.Slug!.Contains(category ?? String.Empty)) && x.Status==true)
                .Include(x => x.ProductImages).OrderByDescending(x => x.SellingCount).Skip(page * 15).Take(15).ToListAsync();
            int count = await _db.Products!.AsNoTracking().Include(x => x.ProductCategory).Where(x =>( x.ProductCategory!.Slug!.Contains(category ?? String.Empty))&& x.Status == true)
                .OrderByDescending(x => x.SellingCount).CountAsync();
            PaginationDTO<List<Product>> result = Pagination<List<Product>>.PaginationMethod(page, 15, count);
            result.Object = products;
            return result;
        }

        public async Task<List<Product>> GetSellingProducts()
        {
            return (await _db.Products!.AsNoTracking().Where(x => x.Status == true).Include(x => x.ProductImages).OrderByDescending(x => x.SellingCount).Take(20).ToListAsync());
        }

        public async Task<ShoppingDTO> GetShoppingItems()
        {
            string cookie = _httpContextAccessor?.HttpContext?.Request.Cookies["shopping-key"]!;
            List<int> shoppingsConvertObject = new();
            if (cookie is not null)
            {
                shoppingsConvertObject = JsonSerializer.Deserialize<List<int>>(cookie)!;
            }

            List<Product> result = new();
            foreach (int item in shoppingsConvertObject)
            {
                Product? product = await _db.Products?.AsNoTracking().Include(x=>x.ProductCategory).FirstOrDefaultAsync(x => x.Id == item)!;
                if (product is null)
                {
                    continue;
                }
                if (product?.Discount?? false)
                {
                    product.Price = ((product.Price * (100 - product.DiscountRate)) / 100);
                }
                result.Add(product?? new Product());
            }
            return new ShoppingDTO { Products=result,TotalPrice= Math.Round(result.Sum(x => x.Price), 2) };
        }

        public async Task<List<Slide>> GetSlides()
        {
            bool result = _cache.TryGetValue("Slides", out List<Slide> slides);
            if (!result)
            {
                slides = await _db.Slides!.AsNoTracking().Where(x => x.Status == true).OrderBy(x => x.Order).ToListAsync();
                _cache.Set("Slides", slides);
            }
            return slides;
        }

        public async Task<PaginationDTO<List<Product>>> SearchedProduct(string searchKey,int page)
        {
            List<Product> products = await _db.Products!.AsNoTracking().Include(x => x.ProductCategory).Where(x => x.Title!.Contains(searchKey?? String.Empty) || x.Description!.Contains(searchKey?? String.Empty) || x.ProductCategory!.Title!.Contains(searchKey?? String.Empty)).Include(x => x.ProductImages).OrderByDescending(x => x.SellingCount).Skip(page * 15).Take(15).ToListAsync();
            int count = await _db.Products!.AsNoTracking().Include(x => x.ProductCategory).Where(x => x.Title!.Contains(searchKey?? String.Empty) || x.Description!.Contains(searchKey?? String.Empty) || x.ProductCategory!.Title!.Contains(searchKey?? String.Empty)).Include(x => x.ProductImages)
                .OrderByDescending(x => x.SellingCount).CountAsync();
            PaginationDTO<List<Product>> result = Pagination<List<Product>>.PaginationMethod(page, 15, count);
            result.Object = products;
            return result;
        }

        public async Task<bool> SendMessage(Message message)
        {
            await _db.Messages!.AddAsync(message);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ShoppingDTO> SetShoppingitem(int id)
        {
            string cookie = _httpContextAccessor?.HttpContext?.Request.Cookies["shopping-key"]!;
            List<int> shoppingsConvertObject = new();
            if (cookie is not null)
            {
                shoppingsConvertObject = JsonSerializer.Deserialize<List<int>>(cookie)!;
            }
            shoppingsConvertObject.Add(id);
            string shoppingsConvertJson = JsonSerializer.Serialize(shoppingsConvertObject);
            List<Product> result = new();
            int count = 0;
            foreach (int item in shoppingsConvertObject)
            {
                Product? product = await _db.Products?.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==item)!;
                if (product is null)
                {
                    continue;
                }
                if(product?.Discount?? false)
                {
                    product.Price = ((product.Price * (100 - product.DiscountRate)) / 100);
                }
                count++;
                result.Add(product?? new Product());
            }
            List<Product> finalResult = new();

            foreach (int item in shoppingsConvertObject.GroupBy(x => x).Select(x => x.FirstOrDefault()))
            {
                Product? product = await _db.Products?.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item)!;
                if (product is null)
                {
                    continue;
                }
                if (product?.Discount?? false)
                {
                    product.Price = ((product.Price * (100 - product.DiscountRate)) / 100);
                }
                product!.SellingCount = shoppingsConvertObject.Where(x => x == product.Id).Count();
                finalResult.Add(product);
            }
            _httpContextAccessor?.HttpContext?.Response.Cookies.Append("shopping-key", shoppingsConvertJson);
            return new ShoppingDTO { Products= finalResult, TotalPrice= Math.Round(result.Sum(x => x.Price), 2), Count= count };
        }
        public async Task<ShoppingDTO> RemoveShoppingItem(int id)
        {
            string cookie = _httpContextAccessor?.HttpContext?.Request.Cookies["shopping-key"]!;
            List<int> shoppingsConvertObject = new();
            if (cookie is not null)
            {
                shoppingsConvertObject = JsonSerializer.Deserialize<List<int>>(cookie)!;
            }
            shoppingsConvertObject.RemoveAll(x=>x==id);
            string shoppingsConvertJson = JsonSerializer.Serialize(shoppingsConvertObject);
            List<Product> result = new();
            foreach (int item in shoppingsConvertObject)
            {
                Product? product = await _db.Products?.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item)!;
                if (product is null)
                {
                    continue;
                }
                if (product?.Discount ?? false)
                {
                    product.Price = ((product.Price * (100 - product.DiscountRate)) / 100);
                }
                result.Add(product ?? new Product());
            }
            List<Product> finalResult = new();
            foreach (int item in shoppingsConvertObject.GroupBy(x => x).Select(x => x.FirstOrDefault()))
            {
                Product? product = await _db.Products?.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item)!;
                if (product?.Discount ?? false)
                {
                    product.Price = ((product.Price * (100 - product.DiscountRate)) / 100);
                }
                if (product is null)
                {
                    continue;
                }
                product!.SellingCount = shoppingsConvertObject.Where(x => x == product.Id).Count();
                finalResult.Add(product);
            }
            _httpContextAccessor?.HttpContext?.Response.Cookies.Append("shopping-key", shoppingsConvertJson);
            return new ShoppingDTO { Products = finalResult, TotalPrice = Math.Round(result.Sum(x => x.Price), 2) };
        }

        public async Task<List<ProductCategory>> GetMainCategories()
        {
            bool result = _cache.TryGetValue("MainProductCategories", out List<ProductCategory> categories);
            if (!result)
            {
                categories = await _db.ProductCategories!.AsNoTracking().Include(x => x.Products).Where(x => x.Status == true && x.ParentId==0).OrderBy(x => x.CreatedDate).ToListAsync();
                _cache.Set("MainProductCategories", categories);
            }
            return categories;
        }

        public async Task<ProductCategory> GetProductCategoryBySlug(string slug)
        {
            return (await _db.ProductCategories!.AsNoTracking().Include(x => x.Products).FirstOrDefaultAsync(x => x.Slug==slug))!;
        }

        public void ProductSellingCount(List<Product> products)
        {
            foreach (Product item in products)
            {
                Product? product = (_db!.Products!.Find(item.Id))!;
                if (product is not null)
                {
                    product.SellingCount++;
                    _db.SaveChanges();
                }
            }
        }

        public async Task<Dictionary<string, string>> GetSettings()
        {
            bool result = _cache.TryGetValue("Settings", out Dictionary<string,string> settings);
            if (!result)
            {
                settings = (await _db.Settings!.AsNoTracking().ToDictionaryAsync(x=>x.Key!,x=>x.Value!));
                _cache.Set("Settings", settings);
            }
            return settings;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _db.Orders!.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }
    }
}
