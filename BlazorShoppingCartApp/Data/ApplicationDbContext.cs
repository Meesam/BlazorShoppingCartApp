using BlazorShoppingCartApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorShoppingCartApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImages> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Jeans", Description="This is product one", Price=20.8,Quantity=5 },
                new Product { Id = 2, Name = "T-Shirt", Description = "This is product two",  Price = 50.2, Quantity = 15 },
                new Product { Id = 3, Name = "Jacket", Description = "This is product three", Price = 45.3, Quantity = 38 }
                );
        }

    }
}
