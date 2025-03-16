using System.ComponentModel.DataAnnotations;

namespace BlazorShoppingCartApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }= string.Empty;

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; } = new List<ProductImages>();
    }
}
