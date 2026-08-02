using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class GameZoneDbContext : IdentityDbContext
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GamerGame>().HasKey(gg => new { gg.GameId, gg.GamerId });

            builder
                .Entity<Genre>()
                .HasData(
                new Genre { Id = 1, Name = "action" },
                new Genre { Id = 2, Name = "adventure" },
                new Genre { Id = 3, Name = "fighting" },
                new Genre { Id = 4, Name = "sports" },
                new Genre { Id = 5, Name = "racing" },
                new Genre { Id = 6, Name = "strategy" });
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GamerGame> GamersGames { get; set; }
    }
}
