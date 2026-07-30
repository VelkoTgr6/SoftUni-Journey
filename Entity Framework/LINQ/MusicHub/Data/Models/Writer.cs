
using MusicHub.Data.Models.Constrains;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(Constants.WriterNameMaxLength)]
        public string Name { get; set; }
        public string? Pseudonym { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        
    }
}
