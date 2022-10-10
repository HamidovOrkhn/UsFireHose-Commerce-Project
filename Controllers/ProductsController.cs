using Microsoft.AspNetCore.Mvc;
using USFH.Models;
using USFH.Repositories;

namespace USFH.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IGeneralRepository _generalRepository;

        public ProductsController(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }
        public async Task<IActionResult> Index(string? category = null, int page=0)
        {
            page--;
            if (page < 0)
            {
                page = 0;
            }
            ViewData["Category"] = category;
            ViewData["ProductCategories"] = await _generalRepository.GetCategories();
            ViewData["MainProductCategories"] = await _generalRepository.GetMainCategories();
            ViewData["NewProducts"] = await _generalRepository.GetNewProducts();
            ViewData["Settings"] = await _generalRepository.GetSettings();
            return View((await _generalRepository.GetProducts(category!, page)));
        }

        [Route("details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            Product product = await _generalRepository.GetProductBySlug(slug);
            ViewData["RelatedProducts"] =await _generalRepository.GetProductByCategory(product?.ProductCategory?.Slug!);
            ViewData["NewProducts"] = await _generalRepository.GetNewProducts();
            ViewData["Settings"] = await _generalRepository.GetSettings();
            return View(product);
        }
    }
}
