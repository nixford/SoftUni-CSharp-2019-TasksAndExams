

using System.ComponentModel.DataAnnotations;

namespace MUSACA.ViewModels.BindingModels.Users
{
    public class UserRegisterInputModel
    {
        private const string UsernameErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        private const string PasswordErrorMessage = "Invalid password length!";

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]        
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
