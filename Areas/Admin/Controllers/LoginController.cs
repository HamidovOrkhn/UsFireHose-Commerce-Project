using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using USFH.Areas.Admin.DTOs;
using USFH.Areas.Admin.Filters;
using USFH.Database;
using USFH.Libs;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context;
        }
        [LogoutFilter]
        [Route("/admin/login")]
        public IActionResult Login()
        {
            return View();
        }
        [LogoutFilter]
        [HttpPost]
        [Route("/admin/login")]
        public IActionResult Login(LoginDTO request)
        {
            if (!ModelState.IsValid)
            {
                return View("login", request);
            }
            ClaimsIdentity identity = null!;
            var user = _context.Users!.Where(x => x.Email == request.Email && x.Status==true).FirstOrDefault();
            if (user is null)
            {
                TempData["Server-Error"] = "There is no such user";
                return View("login");
            }
            if ( user.Password != PasswordHash.HashPass(request?.Password?? String.Empty))
            {
                TempData["Server-Error"] = "Wrong Password";
                return View("login");
            }
            identity = new ClaimsIdentity(
            new[] {
                    new Claim(ClaimTypes.Name,user?.Name!),
                    new Claim(ClaimTypes.Email,user?.Email!),
                    new Claim(ClaimTypes.NameIdentifier, user?.Id!.ToString()!),
          }, CookieAuthenticationDefaults.AuthenticationScheme);
            var Principal = new ClaimsPrincipal(identity);

            var Adminlogin = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal);

            return Redirect("/admin/home");
        }
        [Route("/admin/logout")]
        public IActionResult Logout()
        {
            if (HttpContext?.User?.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value != null)
            {
                HttpContext.SignOutAsync();
                return Redirect("/admin");
            }
            return Redirect("/admin/home");
        }
    }
}
