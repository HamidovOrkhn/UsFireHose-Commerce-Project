using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace USFH.Areas.Admin.Filters
{
    public class LogoutFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Middleware Started");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {

            if (context.HttpContext.User.FindFirstValue(System.Security.Claims.ClaimTypes.Email) != null)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.RedirectResult("/admin");
            }
        }
    }
}
