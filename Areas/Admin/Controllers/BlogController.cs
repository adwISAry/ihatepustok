using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nov30task.Context;
using nov30task.ViewModels.BlogVM;

namespace nov30task.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class BlogController : Controller
    {
        public ApplicationDbContext _db;
        public BlogController( ApplicationDbContext dbContext)
        {
         _db = dbContext;
            
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Blogs.Select(c => new BlogListItemVM { Id = c.Id, Title = c.Title }).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(BlogCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (await _db.Blogs.AnyAsync(s => s.Title == vm.Title))
            {
                ModelState.AddModelError("Name", vm.Title + " adı artıq mövcuddur.");
                return View(vm);
            }
            await _db.Blogs.AddAsync(new Models.Blog { Title = vm.Title });
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _db.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            return View(new BlogUpdateVM { Title = data.Title  });
        }

        [HttpPost]

        public async Task<IActionResult> Update(int? id, BlogUpdateVM vm)
        {
            TempData["CategoryRenovationResponse"] = false;

            if (id == null || id <= 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            data.Title = vm.Title;
            data.Description = vm.Description;
            TempData["CategoryRenovationResponse"] = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task BlogDelete(int id)
       {
            var data = await _db.Blogs.FindAsync(id);
            _db.Blogs.Remove(data);
            await _db.SaveChangesAsync();
       }

        







    }
}
