using System.ComponentModel.DataAnnotations;

namespace BlazorShoppingCartApp.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public int RatingNumber { get; set; }
    }
}
