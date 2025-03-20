using BlazorShoppingCartApp.Models;

namespace BlazorShoppingCartApp.Services
{
    public interface IBrandService
    {
        public Task<IEnumerable<Brand>> GetAllBrand();

        public Task<Brand?> AddBrand(Brand product);

        public Task<Brand?> GetBrandById(int Id);

        public Task<Brand?> UpdateBrand(Product product);

        public Task<bool> DeleteBrand(int Id);
    }
}
