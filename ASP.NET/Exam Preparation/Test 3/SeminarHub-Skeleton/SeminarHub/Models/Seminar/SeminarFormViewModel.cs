using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;
using static SeminarHub.Data.ErrorMessageConstants;

namespace SeminarHub.Models.Seminar
{
    public class SeminarFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarTopicMaxLength,
            MinimumLength = SeminarTopicMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarLecturerMaxLength,
            MinimumLength = SeminarLecturerMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarDetailsMaxLength,
            MinimumLength = SeminarDetailsMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string DateAndTime { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(SeminarDurationMinLength, SeminarDurationMaxLength,
            ErrorMessage = StringLengthErrorMessage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public string OrganizerId {  get; set; }= string.Empty;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
