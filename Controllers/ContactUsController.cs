using Microsoft.AspNetCore.Mvc;
using USFH.Models;
using USFH.Repositories;

namespace USFH.Controllers
{
    [Route("contact-us")]
    public class ContactUsController : Controller
    {
        private readonly IGeneralRepository _generalRepository;
        public ContactUsController(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["Settings"] = await _generalRepository.GetSettings();
            return View(await _generalRepository.GetContactUs());
        }
        [HttpPost]
        [Route("sendmessage")]
        public async Task<IActionResult> SendMessage([FromBody] Message request)
        {
            if (!ModelState.IsValid)
            {
                return Json(false);
            }
            bool result=await _generalRepository.SendMessage(request);
            return Json(result);
        }
    }
}
