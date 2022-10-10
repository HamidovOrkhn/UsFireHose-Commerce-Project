using Microsoft.AspNetCore.Mvc;
using USFH.Areas.Admin.Filters;
using USFH.Database;
using USFH.Libs;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class HomeController : Controller
    {
        public readonly DataContext _context;
        private readonly IMyCache _myCache;
        public HomeController(DataContext context,IMyCache myCache)
        {
            _context = context;
            _myCache = myCache;
        }
        public IActionResult Index()
        {
            ViewData["Message_Count"]=_context?.Messages?.Count();
            ViewData["Product_Count"]=_context?.Products?.Count();
            ViewData["Blog_Count"]=_context?.Blogs?.Count();
            return View();
        }
        [Route("admin/home/clearcache")]
        public IActionResult ClearCache(string url)
        {
            _myCache.Clear();
            return Redirect(url);
        }
    }
}
