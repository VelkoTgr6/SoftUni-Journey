using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class Event
    {
        [Key]
        [Comment("Primary key")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.EventNameMaxLength)]
        [Comment("Name of the event")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.EventDescriptionMaxLength)]
        [Comment("Description of the event")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string OrganiserId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OrganiserId))]
        [Comment("Organizer of the event")]
        public IdentityUser Organiser { get; set; } = default!;

        [Required]
        [Comment("Date and Time of the event was created on")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Date and Time of the event starts")]
        public DateTime Start { get; set; }

        [Required]
        [Comment("Date and Time of the event ends")]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        [ForeignKey(nameof(TypeId))]
        [Comment("Type of the event")]
        public Type Type { get; set; } = default!;

        [Comment("Participants of the event")]
        public IList<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();


    }
}
