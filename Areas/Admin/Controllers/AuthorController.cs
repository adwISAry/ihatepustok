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
               
                return View(vm);
            }
            if (await Context.Auhtors.AnyAsync(s => s.Surname == vm.Surname))
            {
                
                return View(vm);
            }
            await Context.Auhtors.AddAsync(new Models.Author { Name = vm.Name, Surname = vm.Surname});
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public AuthorController(ApplicationDbContext context)
        {
           Context = context;

        }
        public ApplicationDbContext Context  { get; set; }



        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await Context.Auhtors.FindAsync(id);
            if (data == null) return NotFound();
            return View(new AuthorUpdateVM { Name = data.Name, Surname = data.Surname});
        }

        [HttpPost]

        public async Task<IActionResult> Update(int? id, AuthorUpdateVM vm)
        {
            TempData["CategoryRenovationResponse"] = false;

            if (id == null || id <= 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await Context.Auhtors.FindAsync(id);
            if (data == null) return NotFound();
            data.Name = vm.Name;
            data.Surname = vm.Surname;
            TempData["CategoryRenovationResponse"] = true;
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await Context.Auhtors.FindAsync(id);
            if (data == null) return NotFound();
            Context.Auhtors.Remove(data);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }
        }
    }
