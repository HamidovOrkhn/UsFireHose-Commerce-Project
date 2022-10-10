using Microsoft.AspNetCore.Mvc;
using Slugify;
using USFH.Areas.Admin.Controllers.Base;
using USFH.Areas.Admin.Filters;
using USFH.Database;
using USFH.Models;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class BlogController : BaseController<Blog>
    {
        public BlogController(DataContext context) : base(context)
        {

        }
        public override Task<IActionResult> Create(Blog model)
        {
            SlugHelper helper = new();
            model.Slug = helper.GenerateSlug(DateTime.Now.ToString("fffff") + "-" + model.Title);
            return base.Create(model);
        }
        public override Task<IActionResult> Edit(int id, Blog model)
        {
            SlugHelper helper = new();
            model.Slug = helper.GenerateSlug(DateTime.Now.ToString("fffff") + "-" + model.Title);
            return base.Edit(id, model);
        }
    }
}
