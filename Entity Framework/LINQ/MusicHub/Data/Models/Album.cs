using MusicHub.Data.Models.Constrains;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(Constants.AlbumNameMaxLength)]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public decimal Price => Songs.Sum(s => s.Price);
        public int? ProducerId { get; set; }
        [ForeignKey(nameof(ProducerId))]
        public virtual Producer? Producer { get; set; }
        public virtual ICollection<Song> Songs { get;set; }

    }
}