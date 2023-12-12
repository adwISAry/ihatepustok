using Microsoft.EntityFrameworkCore;
using nov30task.Models;

namespace nov30task.ViewModels.AuthorVM
{
    public class AuthorIndex
    {
        public string Name { get; set; }

        public string Surname { get; set; }
   
        public IEnumerable<Author> Authors { get; set; }
    }
}
