using Microsoft.AspNetCore.Mvc;
using USFH.Models;
using USFH.Repositories;

namespace USFH.Controllers
{
    public class CategoryController : Controller
    {
        public readonly IGeneralRepository _generalRepository;
        public CategoryController(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }
        [Route("category/{slug}")]
        public async Task<IActionResult> Index(string slug)
        {

            ProductCategory category = await _generalRepository.GetProductCategoryBySlug(slug);
            ViewData["Settings"] = await _generalRepository.GetSettings();
            ViewData["ProductCategories"] = await _generalRepository.GetCategories();
            return View(category);
        }
    }
}
