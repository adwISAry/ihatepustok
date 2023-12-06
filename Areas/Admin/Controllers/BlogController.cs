using Microsoft.AspNetCore.Mvc;
using nov30task.Context;

namespace nov30task.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public ApplicationDbContext _db;
        public BlogController( ApplicationDbContext dbContext)
        {
         _db = dbContext;
            
        }
        
       public async Task BlogDelete(int id)
       {
            var data = await _db.Blogs.FindAsync(id);
            _db.Blogs.Remove(data);
            await _db.SaveChangesAsync();
       }    
    }
}
