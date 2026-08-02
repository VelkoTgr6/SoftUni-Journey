using GameZone.Models.Genre;
using System.ComponentModel.DataAnnotations;
using static GameZone.Data.DataConstants;
using static GameZone.Data.ErrorMessageConstants;

namespace GameZone.Models.Game
{
    public class GameFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(GameTitleMaxLength,
            MinimumLength=GameTitleMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        public string ?ImageUrl { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(GameTitleMaxLength,
            MinimumLength = GameTitleMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string ReleasedOn { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public int GenreId { get; set; }

        public string PublisherId { get; set; } = string.Empty;
        public IEnumerable<GenreViewModel>Genres { get; set; } = new List<GenreViewModel>();


    }
}
