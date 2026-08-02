using System.ComponentModel.DataAnnotations;
using static DeskMarket.Constants.ModelConstants;
using static DeskMarket.Constants.ErrorMessageConstants;
using DeskMarket.Models.Category;

namespace DeskMarket.Models.Product
{
    public class ProductFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ProductNameMaxLength,
            MinimumLength = ProductNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ProductNameMaxLength,
            MinimumLength = ProductNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(ProductPriceMinValue, 
            ProductPriceMaxValue,
            ErrorMessage = "Price must be in range {1} and {2}")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [RegularExpression(RegexDateFormat, ErrorMessage = AddedOnFormatErrorMessage)]
        public string AddedOn { get; set; } = string.Empty;

        public string SellerId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
