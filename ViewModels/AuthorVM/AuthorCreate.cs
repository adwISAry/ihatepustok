using nov30task.Models;
using System.ComponentModel.DataAnnotations;

namespace nov30task.ViewModels.AuthorVM
{
    public class AuthorCreate
    {
        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; set; }

        [MinLength(3), MaxLength(32)]
        public string Surname { get; set; }
    }
}
