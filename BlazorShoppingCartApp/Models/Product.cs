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

        public Double Price { get; set; }
        public string PriceString{ get => Price.ToString();
            set{
                if(Double.TryParse(value, out double val))
                    Price = val;
            }
        }

        public Double CostPrice { get; set; }
        public string CostPriceString{ get => CostPrice.ToString();
            set{
                if(Double.TryParse(value, out double val))
                    CostPrice = val;
            }
        }
        
        public Double BulkDiscountPrice { get; set; }
        public string BulkDiscountPriceString{ get => BulkDiscountPrice.ToString();
            set{
                if(Double.TryParse(value, out double val))
                    BulkDiscountPrice = val;
            }
        }
        
        public Double TaxRate { get; set; }
        public string TaxRateString{ get => TaxRate.ToString();
            set{
                if(Double.TryParse(value, out double val))
                    TaxRate = val;
            }
        }
        public ICollection<ProductImages> ProductImages { get; set; } = new List<ProductImages>();
    }
}
