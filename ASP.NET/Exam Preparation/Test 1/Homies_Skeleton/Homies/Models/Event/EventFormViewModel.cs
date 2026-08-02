using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;
using static Homies.Data.ErrorConstants;

namespace Homies.Models.Event
{
    public class EventFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(EventNameMaxLength,
            MinimumLength = EventNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Comment("Name of the event")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(EventDescriptionMaxLength,
            MinimumLength = EventDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Comment("Description of the event")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Comment("Date and Time of the event starts")]
        public string Start { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Comment("Date and Time of the event ends")]
        public string End { get; set; }= string.Empty;

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();

    }
}
