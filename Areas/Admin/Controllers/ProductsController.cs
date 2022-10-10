using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Slugify;
using USFH.Areas.Admin.Controllers.Base;
using USFH.Areas.Admin.DTOs.LinkProduct;
using USFH.Areas.Admin.Filters;
using USFH.Database;
using USFH.Models;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Net;
using System.Drawing.Imaging;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class ProductsController : BaseController<Product>
    {
        public readonly DataContext _context;
        public ProductsController(DataContext context) : base(context)
        {
            _context = context;
        }
        public async override Task<IActionResult> Index()
        {
            List<Product> products = await _context?.Products?.Include(x => x.ProductCategory).ToListAsync()!;
            return View(products);
        }
        [HttpGet("admin/products/alter/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = ProductCategories();

            var model = await _context.Products!.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost("admin/products/alter")]
        public async Task<IActionResult> Edit(Product model)
        {
            ViewData["Categories"] = ProductCategories();
            try
            {
                SlugHelper helper = new();
                model.Slug = helper.GenerateSlug(DateTime.Now.ToString("fffff") + "-" + model.Title);
                ModelState.Clear();
                if (TryValidateModel(model))
                {
                    if (_context?.Products?.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == model!.Id)?.ProductImages is not null)
                    {
                        var d = _context?.Products?.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == model!.Id)?.ProductImages;
                        _context?.ProductImages?.RemoveRange(d!);
                    }
                    _context?.SaveChanges();
                    _context?.ChangeTracker.Clear();
                    if (model?.ProductImages is not null)
                    {
                        await (_context?.ProductImages?.AddRangeAsync(model.ProductImages.Select(x => { x.ProductId = model.Id; return x; }).ToList()))!;
                    }
                    _context?.SaveChanges();
                    _context?.ChangeTracker.Clear();
                    _context?.Products!.Update(model!);

                    await _context!.SaveChangesAsync().ConfigureAwait(false);

                    string? controllerName = this.ControllerContext.RouteData.Values["controller"]?.ToString()?.ToLower();
                    string? areaName = this.ControllerContext.RouteData.Values["area"]?.ToString()?.ToLower();
                    return Redirect($"/{areaName}/{controllerName}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }


        public override IActionResult Create()
        {
            ViewData["Categories"] = ProductCategories();
            return base.Create();
        }
        [HttpPost]
        [Route("admin/products/add")]
        public override Task<IActionResult> Create(Product model)
        {
            SlugHelper helper = new();
            model.Slug = helper.GenerateSlug(DateTime.Now.ToString("fffff") + "-" + model.Title);
            ViewData["Categories"] = ProductCategories();
            return base.Create(model);
        }

        private SelectList ProductCategories()
        {
            List<ProductCategory> menus = new();
            List<ProductCategory> allMenus = _context.ProductCategories!.ToList();
            foreach (ProductCategory item in allMenus)
            {
                if (_context.ProductCategories!.Any(x => x.ParentId == item.Id))
                {
                    continue;
                }
                menus.Add(item);
            }
            return new SelectList(menus, "Id", "Title");
        }

        [HttpGet]
        [Route("admin/products/createbylink")]
        public IActionResult CreateByLink()
        {
            ViewData["Categories"] = ProductCategories();
            return View();
        }

        [HttpPost]
        [Route("admin/products/createbylink")]
        public async Task<IActionResult> CreateByLink(CreateByLinkRequestDTO request)
        {
            try
            {
                ViewData["Categories"] = ProductCategories();
                CreateByLinkResponseDTO? data = null;
                List<Product> products = new();
                using (HttpClient client = new())
                {
                    await client.GetAsync(request.Link).ContinueWith(async response =>
                    {
                        SlugHelper helper = new();
                        HttpResponseMessage httpResponseMessage = await response;
                        using (Stream responseStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                        using (GZipStream deflateStream = new(responseStream, CompressionMode.Decompress))
                        using (StreamReader streamReader = new(deflateStream))
                        {
                            var str = streamReader.ReadToEnd();
                            data = JsonConvert.DeserializeObject<CreateByLinkResponseDTO?>(str);
                            products.AddRange(data!.data!.items!.Select(item => new Product
                            {
                                CategoryId = request.CategoryId,
                                SellingCount = 0,
                                Discount = false,
                                DiscountRate = 0,
                                Slug = helper.GenerateSlug(DateTime.Now.ToString("fffff") + "-" + item?.title) ?? "Empty",
                                Description = item?.metafields?.FirstOrDefault(x => x.key == "specifications")?.value?.ToString() ?? "Empty",
                                ItemNumber = item?.variants?.FirstOrDefault()?.sku,
                                Weight = Math.Round((decimal?)(item?.variants?.FirstOrDefault()?.weight * 0.00220462262185) ?? 0, 3),
                                Price = item?.variants?.FirstOrDefault()?.price ?? 0,
                                Status = true,
                                StockStatus = true,
                                StockLevel = item?.metafields?.FirstOrDefault(x => x.key == "ready_to_ship")?.value?.ToString() ?? "Empty",
                                Title = item?.title,
                                ProductFeatures = item?.metafields?.FirstOrDefault(x => x.key == "bullets")?.value?.ToString() ?? "Empty",
                                ProductImages = GetProductImages(item?.images!, item?.title!),
                                ImageLink = GetProductFirstImage(item?.images!) ?? "Empty"
                            }));
                        }
                    });
                }

                await _context!.Products!.AddRangeAsync(products);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "Success";
                return View(request);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(request);
            }
        }

        public List<ProductImage> GetProductImages(List<Image> request, string title)
        {
            List<ProductImage> images = new();
            foreach (var image in request.TakeLast(request.Count - 1).ToList())
            {
                string imageName = "/uploads/Products/" + Guid.NewGuid().ToString() + ".jpg";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + imageName);
                using (HttpClient webClient = new())
                {
                    byte[] data = webClient.GetByteArrayAsync("https:" + image.url).Result;
                    System.IO.File.WriteAllBytes(path, data);
                    images.Add(new ProductImage { ImageLink = imageName, Title = title });
                }
            }
            return images;
        }
        public string GetProductFirstImage(List<Image> request)
        {
            string imageName = "/uploads/Products/" + Guid.NewGuid().ToString() + ".jpg";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + imageName);
            using (HttpClient webClient = new())
            {
                byte[] data = webClient.GetByteArrayAsync("https:" + request.FirstOrDefault()?.url).Result;
                System.IO.File.WriteAllBytes(path, data);
            }
            return imageName;
        }
    }
}
