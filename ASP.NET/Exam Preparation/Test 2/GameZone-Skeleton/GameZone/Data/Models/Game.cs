using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Data.DataConstants;


namespace GameZone.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        public string Description { get; set; }= string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        public string PublisherId {  get; set; } = string.Empty ;

        [Required]
        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = default!;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        public int GenreId {  get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre? Genre { get; set; }

        public IList<GamerGames> GamersGames { get; set; } = new List<GamerGames>();
    }
}
