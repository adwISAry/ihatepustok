using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nov30task.Areas.Admin.ViewModels;
using nov30task.Context;
using nov30task.ViewModels;
using nov30task.ViewModels.HomeIndexVM;
using nov30task.ViewModels.SliderVM;

namespace nov30task.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context { get; }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {
           
            var model = new HomeIndex();
            model.Products =(await _context.Products.ToListAsync()).Select(a=> new AdminProductListItemVM()
            {
                Name= a.Name,
                Category = a.Category,
                CostPrice = a.CostPrice,
                SellPrice = a.SellPrice,
                Discount = a.Discount,
                ImageUrl = a.ImageUrl,
                Quantity = a.Quantity,
                Id = a.Id,

            });

            model.Sliders = (await _context.Sliders.ToListAsync()).Select(a=> new SliderListItemVM());
            return View(model);
        }




    }
}
