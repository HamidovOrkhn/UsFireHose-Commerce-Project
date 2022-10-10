using Microsoft.AspNetCore.Mvc;
using USFH.Repositories;

namespace USFH.Controllers
{
    [Route("about-us")]
    public class AboutUsController : Controller
    {
        private readonly IGeneralRepository _generalRepository;
        public AboutUsController(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Settings"]=await _generalRepository.GetSettings();
            return View(await _generalRepository.GetAboutUs());
        }
    }
}
