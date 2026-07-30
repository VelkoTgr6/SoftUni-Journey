

using MusicHub.Data.Models.Constrains;
using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(Constants.SongNameMaxLength)]
        public string Name { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public int? AlbumId {  get; set; }
        [ForeignKey(nameof(AlbumId))]
        public virtual Album? Album { get; set; }
        [Required]
        public int WriterId {  get; set; }
        [ForeignKey(nameof(WriterId))]
        public virtual Writer Writer { get; set; }

        public decimal Price {  get; set; }
        public virtual ICollection<SongPerformer>SongPerformers { get; set; }
    }
}
