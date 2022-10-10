using Microsoft.AspNetCore.Mvc;
using USFH.Models;
using USFH.Areas.Admin.Controllers.Base;
using USFH.Database;
using USFH.Areas.Admin.Filters;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class MessageController : BaseController<Message>
    {
        public MessageController(DataContext context) : base(context)
        {

        }
    }
}
