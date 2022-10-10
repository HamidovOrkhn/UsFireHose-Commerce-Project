using Microsoft.AspNetCore.Mvc;
using USFH.Areas.Admin.Controllers.Base;
using USFH.Areas.Admin.Filters;
using USFH.Areas.Admin.Models;
using USFH.Database;
using USFH.Libs;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class UserController : BaseController<User>
    {
        private readonly DataContext _context;
        public UserController(DataContext context) : base(context)
        {
            _context = context;
        }
        [Route("admin/user/add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("admin/user/add")]
        public async Task<IActionResult> Add(User model)
        {
            try
            {
                ModelState.Clear();
                if (TryValidateModel(model))
                {
                    if (_context!.Users!.Any(x => x.Email == model.Email))
                    {
                        ModelState.AddModelError("", "This email is already use");
                        return View(model);
                    }
                    model.Password = PasswordHash.HashPass(model?.Password ?? String.Empty);
                    await _context!.AddAsync(model!);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    string? controllerName = this.ControllerContext.RouteData.Values["controller"]?.ToString()?.ToLower();
                    string? areaName = this.ControllerContext.RouteData.Values["area"]?.ToString()?.ToLower();
                    return Redirect($"/{areaName}/{controllerName}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        [Route("admin/user/alter/{id}")]
        public async Task<IActionResult> Alter(int? id)
        {
            if (id == null)
                return NotFound();

            var model = await _context!.Users!.FindAsync(id).ConfigureAwait(false);

            if (model == null)
                return NotFound();

            return View(model);
        }
        [HttpPost]
        [Route("admin/user/alter")]
        public async Task<IActionResult> Alter(User model)
        {
            try
            {
                ModelState.Clear();
                model.Password = "Pass";
                if (TryValidateModel(model))
                {
                    User? user = await _context!.Users!.FindAsync(model.Id);
                    if (_context!.Users!.Any(x => x.Email == model.Email))
                    {
                        if (user?.Email != model.Email)
                        {
                            ModelState.AddModelError("", "This email is already use");
                            return View(model);
                        }
                    }

                    user!.Name = model.Name;
                    user.Email = model.Email;
                    user.Status = model.Status;
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    string? controllerName = this.ControllerContext.RouteData.Values["controller"]?.ToString()?.ToLower();
                    string? areaName = this.ControllerContext.RouteData.Values["area"]?.ToString()?.ToLower();
                    return Redirect($"/{areaName}/{controllerName}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }
    }
}
