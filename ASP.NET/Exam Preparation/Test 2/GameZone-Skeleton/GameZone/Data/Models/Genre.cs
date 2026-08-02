using System.ComponentModel.DataAnnotations;
using static GameZone.Data.DataConstants;

namespace GameZone.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Game> Games { get; set; }= new List<Game>();
    }
}
