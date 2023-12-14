using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nov30task.Context;
using nov30task.ViewModels.SliderVM;

namespace nov30task.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        public SliderViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        ApplicationDbContext _context { get; }


        public async Task <IViewComponentResult> InvokeAsync()
        {
            ;

            return View(await _context.Sliders.Select(s=> new SliderListItemVM
            {
                Id = s.Id,
                ImageUrl = s.ImageUrl,
                IsLeft = s.IsLeft,
                Title = s.Title,
                Text = s.Text,
            }).ToListAsync());
        }
    }
}
