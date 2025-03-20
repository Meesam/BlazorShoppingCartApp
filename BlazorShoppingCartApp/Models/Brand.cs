using System.ComponentModel.DataAnnotations;

namespace BlazorShoppingCartApp.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
