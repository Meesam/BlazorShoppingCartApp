using BlazorShoppingCartApp.Models;
using Microsoft.Identity.Client;

namespace BlazorShoppingCartApp.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product?> AddProduct(Product product);

        public Task<Product?> GetProductById(int Id);

        public Task<Product?> UpdateProduct(Product product);

        public Task<bool> DeleteProduct(int Id);
    }
}
