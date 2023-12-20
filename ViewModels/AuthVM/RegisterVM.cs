using System.ComponentModel.DataAnnotations;

namespace nov30task.ViewModels.AuthVM
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Ad ve soyadinizi duzgun qeyd edin!"), MinLength(4, ErrorMessage = "Minimum length is 4 characters"), MaxLength(24, ErrorMessage = "Maximum length is 24 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required"), DataType(DataType.EmailAddress, ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Passwords do not match")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{4,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one digit")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required"), DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{4,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one digit")]
        public string ConfirmPassword { get; set; }
    }

}
