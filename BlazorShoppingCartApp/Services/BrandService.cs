using BlazorShoppingCartApp.Models;

namespace BlazorShoppingCartApp.Services
{
    public class BrandService : IBrandService
    {
        public Task<Brand?> AddBrand(Brand product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBrand(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Brand>> GetAllBrand()
        {
            throw new NotImplementedException();
        }

        public Task<Brand?> GetBrandById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Brand?> UpdateBrand(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
