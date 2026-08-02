using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Constants.ModelConstants;

namespace GameZone.Data
{
    public class Game
    {
        [Key]
        [Comment("Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameTitleMaxLength)]
        [Comment("Title of the game")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        [Comment("Description of the game")]
        public string Description { get; set; } = null!;

        [Comment("Image URL of the game")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Identifier of the game Publisher")]
        public string PublisherId { get; set; } = null!;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        [Comment("Game Genre")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        [Required]
        [Comment("Release Date")]
        public DateTime ReleasedOn { get; set; }

        [Comment("Shows wether game is deleted")]
        public bool IsDeleted { get; set; } = false;

        public IList<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
    }
}
