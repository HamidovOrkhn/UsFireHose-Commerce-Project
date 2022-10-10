using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USFH.Areas.Admin.Controllers.Base;
using USFH.Areas.Admin.Filters;
using USFH.Database;
using USFH.Models;

namespace USFH.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginFilter]
    public class OrderController : BaseController<Order>
    {
        public DataContext _context { get; set; }
        public OrderController(DataContext context) : base(context)
        {
            _context = context;
        }

        public override Task<IActionResult> Index()
        {
            return base.Index();
        }

        public async Task<IActionResult> Details (int id)
        {
            Order order = await _context!.Orders!.Include(x => x.OrderProducts)!.ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == id) ?? new Order();
            return View(order);
        }
    }
}
