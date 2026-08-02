using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        [Comment("Primary key")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TypeNameMaxLength)]
        [Comment("Name of the type")]
        public string Name { get; set; } = string.Empty;

        [Comment("Events of the type")]
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
