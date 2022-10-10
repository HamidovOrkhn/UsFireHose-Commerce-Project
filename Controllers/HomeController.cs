using Microsoft.AspNetCore.Mvc;
using USFH.DTOs;
using USFH.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;
using USFH.Models;
using USFH.Libs;

namespace USFH.Controllers
{
    public class HomeController : Controller
    {
        public readonly IGeneralRepository _generalRepository;
        public readonly IMailService _mailService;
        public readonly IConfiguration _configuration;
        public HomeController(IGeneralRepository generalRepository, IMailService mailService, IConfiguration configuration)
        {
            _generalRepository = generalRepository;
            _mailService = mailService;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Slides"]=await _generalRepository.GetSlides();
            ViewData["MainProductCategories"]=await _generalRepository.GetMainCategories();
            ViewData["ProductCategories"] = await _generalRepository.GetCategories();
            ViewData["NewProducts"] = await _generalRepository.GetNewProducts();
            ViewData["NewBlogs"] = await _generalRepository.GetNewBlogs();
            ViewData["SellingProducts"]=await _generalRepository.GetSellingProducts();
            ViewData["Banners"]=await _generalRepository.GetBanners();
            return View();
        }

        public async Task<IActionResult> Search(string key, int page=0)
        {
            page--;
            if (page < 0)
            {
                page = 0;
            }
            ViewData["SearchKey"] = key;
            ViewData["Settings"] = await _generalRepository.GetSettings();
            ViewData["NewProducts"] = await _generalRepository.GetNewProducts();
            return View(await _generalRepository.SearchedProduct(key, page));
        }

        [HttpGet("setshoppingitem/{id}")]
        public async Task<IActionResult> SetShoppingItem(int id)
        {    
            return Json(await _generalRepository.SetShoppingitem(id));
        }

        [HttpGet("removeshoppingitem/{id}")]
        public async Task<IActionResult> RemoveShoppingItem(int id)
        {
            return Json(await _generalRepository.RemoveShoppingItem(id));
        }

        [HttpGet("checkout")]
        public async Task<IActionResult> Checkout()
        {
            ShoppingDTO result=await _generalRepository.GetShoppingItems();
            ViewData["ShoppingItems"] = result;
            ViewData["Settings"] = await _generalRepository.GetSettings();
            return View();
        }
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(CheckoutDTO checkout)
        {
            if (!ModelState.IsValid)
                return View(checkout);
            ShoppingDTO result = await _generalRepository.GetShoppingItems();
            string order = "";
            List<Product> products=new();
            Order orderRequest = new()
            {
                Name = $"{checkout.Name} {checkout.Surname}",
                Address = checkout.Address,
                Email = checkout.Email,
                Phone = checkout.Phone,
                Desc = checkout.Desc,
                OrderProducts = new()
            };
            if (result?.Products is not null)
            {
                foreach (Product? item in result.Products.GroupBy(x => x.Id).Select(y => y.FirstOrDefault()))
                {
                    orderRequest.OrderProducts.Add(new OrderProduct { ProductId=item!.Id,ProductCount= result.Products.Where(x => x.Id == item?.Id).Count() });
                    order += $" Product name {item?.Title}, Quantity:{result.Products.Where(x => x.Id == item?.Id).Count()}, Category:{item?.ProductCategory?.Title}";
                }
            }
            Order addOrder=await _generalRepository.AddOrder(orderRequest);
            string body = $@"Name:{checkout.Name} Surname:{checkout.Surname} PhoneNumber:{checkout.Phone} Email:{checkout.Email} Address:{checkout.Address} Order Details:{order}, Description:{checkout.Desc}";
            MailDTO request = new() { Body= body,Subject="Orders",ToEmail=_configuration["MainMail"] };
            await _mailService.SendEmailAsync(request);
            HttpContext.Response.Cookies.Delete("shopping-key");
            _generalRepository.ProductSellingCount(result?.Products??new());
            TempData["ShoppingCartResponse"] = true;
            return Redirect("/");
        }

    }
}
