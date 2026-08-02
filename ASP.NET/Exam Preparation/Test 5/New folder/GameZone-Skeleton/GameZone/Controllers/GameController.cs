using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Globalization;
using System.Security.Claims;
using static GameZone.Constants.ModelConstants;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext context;

        public GameController(GameZoneDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model =await context.Games
                .AsNoTracking()
                .Where(m=>m.IsDeleted == false)
                .Select(g=>new GameInfoViewModel()
                {
                    Title = g.Title,
                    Genre=g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(DateFormat),
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameFormViewModel();
            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            var releasedOn = DateTime.Now;

            if (!DateTime.TryParseExact(model.ReleasedOn,
                DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out releasedOn))
            {
                ModelState
                    .AddModelError(nameof(model.ReleasedOn), $"Invalid date! Format must be: {DateFormat}");

                model.Genres = await GetGenres();

                return View(model);
            }

            var entity = new Game()
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                ReleasedOn = releasedOn,
                GenreId = model.GenreId,
                PublisherId = GetUserId(),
            };

            await context.Games.AddAsync(entity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            var entity= await context.Games
                .Where(g=> g.Id == id)
                .Include(g=>g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid Id");
            }

            var currentUser = GetUserId();

            if (entity.GamersGames.Any(gg=>gg.GamerId == currentUser))
            {
                return RedirectToAction(nameof(All));
            }
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
        private async Task<ICollection<GenreViewModel>> GetGenres()
        {
            return await context.Genres
                 .AsNoTracking()
                 .Select(t => new GenreViewModel()
                 {
                    Id= t.Id,
                    Name= t.Name
                 })
                 .ToListAsync();
        }
    }
}
