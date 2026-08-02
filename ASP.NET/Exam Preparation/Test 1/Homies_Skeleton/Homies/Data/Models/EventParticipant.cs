using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        public string HelperId { get; set; }

        [ForeignKey(nameof(HelperId))]
        [Comment("Participant of the event")]
        public IdentityUser Helper { get; set; } = default!;

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("Event the participant is attending")]
        public Event Event { get; set; } = default!;
    }
}
