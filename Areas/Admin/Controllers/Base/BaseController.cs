using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USFH.Areas.Admin.Filters;
using USFH.Database;

namespace USFH.Areas.Admin.Controllers.Base
{
    [LoginFilter]
    public class BaseController<T> : Controller where T : class
    {
        private readonly DataContext _db;

        public BaseController(DataContext db)
        {
            _db = db;
        }

        public virtual async Task<IActionResult> Index()
        {
            if (TempData["DeleteError"] != null)
                ModelState.AddModelError("", (string?)TempData["DeleteError"]!);

            return View(await _db.Set<T>().ToListAsync().ConfigureAwait(false));
        }

        [NonAction]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var model = await _db.Set<T>().FindAsync(id).ConfigureAwait(false);

            if (model == null)
                return NotFound();

            return View(model);
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(T model)
        {
            try
            {
                ModelState.Clear();
                if (TryValidateModel(model))
                {
                    _db.Add(model);
                    await _db.SaveChangesAsync().ConfigureAwait(false);
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

        public virtual async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var model = await _db.Set<T>().FindAsync(id).ConfigureAwait(false);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        
        public virtual async Task<IActionResult> Edit(int id, T model)
        {
            try
            {
                ModelState.Clear();
                if (TryValidateModel(model))
                {
                    _db.Update(model);
                    await _db.SaveChangesAsync().ConfigureAwait(false);

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

        [HttpPost]
        
        public virtual async Task<IActionResult> Delete(int id)
        {
            var model = await _db.Set<T>().FindAsync(id).ConfigureAwait(false);

            try
            {
                _db.Remove(model!);
                await _db.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                TempData["DeleteError"] = ex.Message;
            }
            string? controllerName = this.ControllerContext.RouteData.Values["controller"]?.ToString()?.ToLower();
            string? areaName = this.ControllerContext.RouteData.Values["area"]?.ToString()?.ToLower();
            return Redirect($"/{areaName}/{controllerName}");
        }
    }
}
