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
                                                Quantity = p.Quantity,
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
    }
}
