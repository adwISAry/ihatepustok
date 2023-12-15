using nov30task.Areas.Admin.ViewModels;
using nov30task.ViewModels.SliderVM;
using nov30task.ViewModels.ProductVM;

namespace nov30task.ViewModels.HomeIndexVM
{
    public class HomeIndex
    {
        public IEnumerable<AdminProductListItemVM> Products { get; set; }
        public IEnumerable<SliderListItemVM> Sliders { get; set; }
    }
}
