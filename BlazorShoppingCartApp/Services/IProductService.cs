using BlazorShoppingCartApp.Models;

namespace BlazorShoppingCartApp.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
    }
}
