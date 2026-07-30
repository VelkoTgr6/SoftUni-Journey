

using MusicHub.Data.Models.Constrains;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.PerformerNameMaxLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(Constants.PerformerNameMaxLength)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal NetWorth {  get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
