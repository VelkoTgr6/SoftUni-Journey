using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models
{
    public class GamerGames
    {
        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = default!;

        [Required]
        public string GamerId { get; set; }=string.Empty;

        [ForeignKey(nameof(GamerId))]
        public IdentityUser Gamer { get; set; }=default!;
    }
}
