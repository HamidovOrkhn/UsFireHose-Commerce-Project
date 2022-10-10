using Microsoft.AspNetCore.Mvc;
using USFH.Areas.Admin.Controllers.Base;
using USFH.Areas.Admin.Filters;
using USFH.Database;
using USFH.Models;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class BannerController : BaseController<Banner>
    {
        public BannerController(DataContext context) : base(context)
        {

        }
    }
}
