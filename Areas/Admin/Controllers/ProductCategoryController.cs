using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Slugify;
using USFH.Areas.Admin.Controllers.Base;
using USFH.Areas.Admin.Filters;
using USFH.Database;
using USFH.Models;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class ProductCategoryController : BaseController<ProductCategory>
    {
        private readonly DataContext _context;
        public ProductCategoryController(DataContext context) : base(context)
        {
            _context = context;
        }

        public override Task<IActionResult> Index()
        {
            ViewData["MainCategories"] = MainCategories();
            return base.Index();
        }

        public override IActionResult Create()
        {
            ViewData["MainCategories"] = MainCategories();

            return base.Create();
        }
        public override Task<IActionResult> Create(ProductCategory model)
        {
            SlugHelper helper = new();
            model.Slug = helper.GenerateSlug(DateTime.Now.ToString("fffff") + "-" + model.Title);
            ViewData["MainCategories"] = MainCategories();
            return base.Create(model);
        }
        public override Task<IActionResult> Edit(int? id)
        {
            ViewData["MainCategories"] = MainCategories();
            return base.Edit(id);
        }
        [HttpPost]
        public override Task<IActionResult> Edit(int id, ProductCategory model)
        {
            _context.ChangeTracker.Clear();
            SlugHelper helper = new();
            model.Slug = helper.GenerateSlug(DateTime.Now.ToString("fffff") + "-" + model.Title);
            ViewData["MainCategories"] = MainCategories();
            return base.Edit(id, model);
        }

        public SelectList MainCategories()
        {
            List<ProductCategory>? categories = _context!.ProductCategories!.AsNoTracking().Where(x=>x.ParentId==0).ToList();
            categories.Add(new ProductCategory{Id=0,Title="Main Category" });
            return new SelectList(categories.OrderBy(x=>x.Id),"Id","Title");
        }
    }
}
