using System.ComponentModel.DataAnnotations;

namespace nov30task.ViewModels.CategoryVM
{
    public class CategoryUpdateVM
    {
        [Required, MaxLength(16)]
        public string Name { get; set; }
    }
}
