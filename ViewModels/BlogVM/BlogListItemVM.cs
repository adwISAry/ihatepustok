using nov30task.Models;
using System.ComponentModel.DataAnnotations;

namespace nov30task.ViewModels.BlogVM
{
    public class BlogListItemVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

    }
}
