using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nov30task.Context;
using nov30task.ViewModels.AuthorVM;
using System.Linq;



namespace nov30task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
      


        public IActionResult Index()
        {
            var model = new AuthorIndex();
            model.Authors = Context.Auhtors;
            
            return View(model);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]


        public async Task<IActionResult> Create(AuthorCreate vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (await Context.Auhtors.AnyAsync(s => s.Name == vm.Name))
            {
                ModelState.AddModelError("Name", vm.Name + " adı artıq mövcuddur.");
                return View(vm);
            }
            await Context.Categories.AddAsync(new Models.Category { Name = vm.Name });
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public AuthorController(ApplicationDbContext context)
        {
           Context = context;

        }
        public ApplicationDbContext Context  { get; set; }
        
    }
}
