using Microsoft.AspNetCore.Mvc;
using USFH.Areas.Admin.Controllers.Base;
using USFH.Areas.Admin.Filters;
using USFH.Database;
using USFH.Models;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class ContactUsController : BaseController<ContactUs>
    {
        public ContactUsController(DataContext context) : base(context)
        {

        }
    }
}
