using BlazorShoppingCartApp.Models;
using BlazorShoppingCartApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BlazorShoppingCartApp.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public async Task<bool> Login(LoginUser loginUser)
        {
            if (loginUser is null) return false;

            try
            {
                var user = await _userManager.FindByEmailAsync(loginUser.Email);
                if (user is null) return false;
                var password = await _userManager.CheckPasswordAsync(user, loginUser.Password);
                if (user is not null && password) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> Register(RegisterUser registerUser)
        {
            if (registerUser is null) return false;
            try
            {
                var user = new User
                {
                    UserName = registerUser.Name,
                    Email = registerUser.Email,
                    DateOfBirth = registerUser.DateOfBirth,
                };
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (result.Succeeded)
                {
                    // Optionally, you can assign roles here
                    bool resp = await CreateRoleIfNotExists("User");
                    if (resp)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> CreateRoleIfNotExists(string roleName)
        {
            var result = await _roleManager.RoleExistsAsync(roleName);
            if (!result)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
                return true;
            }
            return true;
        }
    }
}
