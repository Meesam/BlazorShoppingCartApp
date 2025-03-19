using Microsoft.AspNetCore.Identity;

namespace BlazorShoppingCartApp.Models
{
    public class User : IdentityUser
    {
        public DateOnly DateOfBirth { get; set; }
    }
}
