using System.ComponentModel.DataAnnotations;

namespace BlazorShoppingCartApp.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
