using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models.Game;
using GameZone.Models.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        public readonly GameZoneDbContext data;

        public GameController(GameZoneDbContext context)
        {
            data = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await data.Games
                .AsNoTracking()
                .Select(g => new GameAllViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(DataConstants.DataType),
                    Publisher = g.Publisher.UserName
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
            var releasedOn = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.ReleasedOn,
                DataConstants.DataType,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out releasedOn))
            {
                ModelState
                    .AddModelError(nameof(model.ReleasedOn), $"Invalid date! Format must be: {DataConstants.DataType}");
            }

            if (!ModelState.IsValid)
            {
                var genres = await GetGenres();

                return View(model);
            }



            var entity = new Game()
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                ReleasedOn = releasedOn,
                GenreId = model.GenreId,
                PublisherId = GetUserId()
            };



            await data.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            string userId = GetUserId();

            var model = await data.GamersGames
                .Where(gg => gg.GamerId == userId)
                .AsNoTracking()
                .Select(gg => new GameAllViewModel() {
                    Id = gg.GameId,
                    Title = gg.Game.Title,
                    Genre = gg.Game.Genre.Name,
                    ReleasedOn = gg.Game.ReleasedOn.ToString(DataConstants.DataType)
                })
                .ToListAsync();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            var g = await data.Games
                .Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (g == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!g.GamersGames.Any(p => p.GamerId == userId))
            {
                g.GamersGames.Add(new GamerGames()
                {
                    GameId = g.Id,
                    GamerId = userId
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            var game = await data.Games
               .Where(g => g.Id == id)
               .Include(g => g.GamersGames)
               .FirstOrDefaultAsync();

            if (game == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var gamerGame = await data.GamersGames
             .FirstOrDefaultAsync(gg => gg.GameId == id && gg.GamerId == userId);

            if (gamerGame != null)
            {
                // Remove the association between the user and the game
                data.GamersGames.Remove(gamerGame);

                // Save changes to the database
                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var model =await data.Games
                .Where(g=>g.Id==id)
                .AsNoTracking()
                .Select(g=>new GameFormViewModel()
                {
                    Title=g.Title,
                    ImageUrl=g.ImageUrl,
                    Description=g.Description,
                    ReleasedOn=g.ReleasedOn.ToString(DataConstants.DataType),
                    GenreId=g.GenreId
                }).FirstOrDefaultAsync();

            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(GameFormViewModel model,int id)
        {   
            var game = await data.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound("Game Not Found");
            }

            var releasedOn = DateTime.Now;

            if (!DateTime.TryParseExact(
               model.ReleasedOn,
               DataConstants.DataType,
               CultureInfo.InvariantCulture,
               DateTimeStyles.None,
               out releasedOn))
            {
                ModelState
                    .AddModelError(nameof(model.ReleasedOn), $"Invalid date! Format must be: {DataConstants.DataType}");
            }

            var userId = GetUserId();

            if (game.PublisherId != userId)
            {
                return Unauthorized("You don't have permission to edit");
            }

            game.Title = model.Title;
            game.ImageUrl = model.ImageUrl;
            game.Description = model.Description;
            game.ReleasedOn = releasedOn;
            game.GenreId = model.GenreId;

            if (!ModelState.IsValid)
            {
                var genres = GetGenres();
                return View(model);
            }

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            var model = await data.Games
                .AsNoTracking()
                .Where(g => g.Id == id)
                .Select(g => new GameDetailViewModel()
                {
                    Id=g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(DataConstants.DataType),
                    Publisher = g.Publisher.UserName,
                }).FirstOrDefaultAsync();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            var game = await data.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (game == null)
            {
                return NotFound("Game not found");
            }

            var model =await data.Games.
                Where(g => g.Id == id)
                .Select(g => new GameDetailViewModel()
                {
                    Title = g.Title,
                    Publisher = g.Publisher.UserName

                }).FirstOrDefaultAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var game = await data.Games.FindAsync(id);

            if (game==null)
            {
                return NotFound();
            }

            if (game.PublisherId != GetUserId() )
            {
                return BadRequest();
            }

            data.Games.Remove(game);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
        private async Task<IEnumerable<GenreViewModel>> GetGenres()
        {
            return await data.Genres
                .AsNoTracking()
                .Select(g=> new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToListAsync();
        }
    }
}
