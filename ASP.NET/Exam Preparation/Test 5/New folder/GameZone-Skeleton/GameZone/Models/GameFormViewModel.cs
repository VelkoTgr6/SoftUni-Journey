using System.ComponentModel.DataAnnotations;
using static GameZone.Constants.ModelConstants;
using static Library.Data.Constants.ErrorMessageConstants;

namespace GameZone.Models
{
    public class GameFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(GameTitleMaxLength,
            MinimumLength = GameTitleMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public  string Title { get; set; } = string.Empty;

        public string? ImageUrl {  get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(GameDescriptionMaxLength,
            MinimumLength = GameDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public  string Description { get; set; } = string.Empty ;

        [Required(ErrorMessage = RequireErrorMessage)]
        [RegularExpression(RegexDateFormat,ErrorMessage = ReleasedOnFormatErrorMessage)]
        public  string ReleasedOn { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public int GenreId {  get; set; }

        public ICollection<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
