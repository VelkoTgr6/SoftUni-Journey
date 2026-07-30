

using Invoices.Common;
using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(ValidationConstants.ProductPriceMin, ValidationConstants.ProductPriceMax)]
        public decimal Price { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; }
    }
}
