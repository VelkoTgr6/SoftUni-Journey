using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Constants.ModelConstants;

namespace GameZone.Data
{
    public class Genre
    {
        [Key]
        [Comment("Genre Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("Genre Name")]
        public string Name { get; set; } = null!;

        public IList<Game> Games { get; set; } = new List<Game>();
    }
}
