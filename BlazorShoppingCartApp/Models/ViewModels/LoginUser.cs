using System.ComponentModel.DataAnnotations;

namespace BlazorShoppingCartApp.Models.ViewModels
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
