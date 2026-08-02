using static Library.Data.Constants.ErrorMessageConstants;
using static Library.Data.Constants.DataConstants;
using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    public class BookFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(BookTitleMaxLength,
            MinimumLength = BookTitleMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(BookAuthorMaxLength,
            MinimumLength = BookAuthorMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(BookDescriptionMaxLength,
            MinimumLength = BookDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string Url {  get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(BookRatingMinValue, BookRatingMaxValue)]
        public double Rating {  get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId {  get; set; }

        public IEnumerable<CategoryViewModel>Categories { get; set; }=new List<CategoryViewModel>();
    }
}
