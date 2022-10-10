using Microsoft.AspNetCore.Mvc;

namespace USFH.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            if (statusCode == 404)
            {
                ViewBag.StatusCode = 404;
                ViewBag.ErrorTitle = "Oops! This Page Could Not Be Found";
                ViewBag.ErrorBody = "Sorry but the page you are looking for does not exist, have been removed. name changed or is temporarily unavailable";
            }
            else
            {
                ViewBag.StatusCode = 500;
                ViewBag.ErrorTitle = "Oooops! Internal Server Error. That is, something went terribly wrong.";
                ViewBag.ErrorBody = "Don't worry, we've been reported about that.";
            }
            return View("Error");
        }
    }
}
