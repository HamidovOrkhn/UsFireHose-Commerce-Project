using Microsoft.AspNetCore.Mvc;
using USFH.Areas.Admin.Filters;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
	[LoginFilter]
	public class FileManagerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
