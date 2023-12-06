using nov30task.Models;
using System.ComponentModel.DataAnnotations;

namespace nov30task.ViewModels.BlogVM
{
    public class BlogUpdateVM
    {
        [Required, MinLength(3), MaxLength(32)]
        public string Title { get; set; }

        [MinLength(3), MaxLength(64)]
        public string Description { get; set; }
        [Required, MinLength(3), MaxLength(32)]

        public Author Author { get; set; }
    }
}

