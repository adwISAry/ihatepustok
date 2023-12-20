using System.ComponentModel.DataAnnotations;

namespace nov30task.ViewModels.AuthVM
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Ad ve soyadinizi duzgun qeyd edin!"),MinLength(4), MaxLength(24)]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    
        [Required, DataType(DataType.Password), Compare(nameof(ConfirmPassword)), RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]). {4,}$")]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]). {4,}$")]
        public string ConfirmPassword { get; set; }
    }
}
