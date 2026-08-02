using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DeskMarket.Constants.ModelConstants;

namespace DeskMarket.Data.Models
{
    public class Product
    {
        [Key]
        [Comment("Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [Comment("Name of Product")]
        public string ProductName { get; set; } = null!;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [Comment("Description of the Product")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Price of the Product")]
        public decimal Price {  get; set; }

        [Comment("Image URL of the Product")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Identifier of the product Seller")]
        public string SellerId { get; set; } = null!;

        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; } = null!;

        [Required]
        [Comment("Product Category")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Added On Date")]
        public DateTime AddedOn { get; set; }

        [Comment("Shows wether game is deleted")]
        public bool IsDeleted { get; set; } = false;

        public IList<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
    }
}
