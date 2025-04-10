using BlazorShoppingCartApp.Data;
using BlazorShoppingCartApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorShoppingCartApp.Services
{
    public class ProductService : IProductService
    {

        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> AddProduct(Product product)
        {
            if (product is null) return null;
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            if (Id <= 0) return false;
            try
            {
                Product? product = await _context.Products.FindAsync(Id);
                if (product is null) return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Product?> GetProductById(int Id)
        {
            if (Id <= 0) return null;
            return await _context.Products.FindAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<Product> products = await (from p in _context.Set<Product>()
                                            from i in _context.Set<ProductImages>().Where(i => p.Id == i.ProductId).DefaultIfEmpty()
                                            select new Product
                                            {
                                                Id = p.Id,
                                                Name = p.Name,
                                                Description = p.Description,
                                                Price = p.Price,
                                                ProductImages = i != null ? new List<ProductImages>
                                          {
                                              new ProductImages
                                              {
                                                  Id = i.Id,
                                                  ProductId = i.ProductId,
                                                  ImageUrl = i.ImageUrl
                                              }
                                          } : new List<ProductImages>()
                                            }).ToListAsync();
            return products;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            if (product is null) return null;
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
