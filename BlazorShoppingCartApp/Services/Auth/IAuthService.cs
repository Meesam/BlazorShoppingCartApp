using BlazorShoppingCartApp.Models.ViewModels;

namespace BlazorShoppingCartApp.Services.Auth
{
    public interface IAuthService
    {
        Task<bool> Login(LoginUser loginUser);
        Task<bool> Register(RegisterUser registerUser);
    }
}
