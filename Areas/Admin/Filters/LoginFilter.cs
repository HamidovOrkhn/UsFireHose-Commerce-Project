using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace USFH.Areas.Admin.Filters
{
    public class LoginFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.FindFirstValue(System.Security.Claims.ClaimTypes.Email) == null && context.HttpContext.Request.Cookies["GlobalLogin"] == null)
            {
                context.Result = new RedirectResult("/admin/login");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Middleware Started");
        }
    }
}
