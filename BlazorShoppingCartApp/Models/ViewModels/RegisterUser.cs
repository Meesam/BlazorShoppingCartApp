using System.ComponentModel.DataAnnotations;

namespace BlazorShoppingCartApp.Models.ViewModels
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
