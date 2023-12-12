using Microsoft.AspNetCore.Mvc;
using nov30task.Context;
using nov30task.ViewModels.AuthorVM;

namespace nov30task.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            var model = new AuthorIndex();
            model.Authors = Context.Auhtors;
            
            return View(model);

        }
       public AuthorController(ApplicationDbContext context)
        {
           Context = context;

        }
        public ApplicationDbContext Context { get; set; }
        
    }
}
