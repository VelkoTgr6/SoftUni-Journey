using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using static GameZone.Constants.ModelConstants;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var model = await context.Games
                .Where(g=>g.IsDeleted == false)
                .Select(g=>new GameInfoViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ReleasedOn = g.ReleasedOn.ToString(DateFormat)
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameFormViewModel();
            model.Genres =await GetGenres();

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
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out releasedOn))
            {
                ModelState
                    .AddModelError(nameof(model.ReleasedOn), $"Invalid date! Format must be: {DateFormat}");
                model.Genres = await GetGenres();

                return View(model);
            }


            var game = new Game()
            {
                Title = model.Title,
                ImageUrl=model.ImageUrl,
                Description = model.Description,
                PublisherId = GetUserId(),
                ReleasedOn = releasedOn,
                GenreId=model.GenreId
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id)
                .Where(g=>g.IsDeleted == false)
                .AsNoTracking()
                .Select(g => new GameFormViewModel()
                {
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(DateFormat),
                    GenreId = g.GenreId
                })
                .FirstOrDefaultAsync();

            model.Genres= await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameFormViewModel model,int id)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            var releasedOn = DateTime.Now;

            if (!DateTime.TryParseExact(model.ReleasedOn,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out releasedOn))
            {
                ModelState
                    .AddModelError(nameof(model.ReleasedOn), $"Invalid date! Format must be: {DateFormat}");
                model.Genres = await GetGenres();

                return View(model);
            }

            var entity = await context.Games.FindAsync(id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }

            var currentUser=GetUserId();

            if (entity.PublisherId != currentUser)
            {
                return RedirectToAction(nameof(All));
                //moje exception ili tn....
            }

            entity.Title = model.Title;
            entity.ImageUrl = model.ImageUrl;
            entity.Description = model.Description;
            entity.ReleasedOn = releasedOn;
            entity.GenreId = model.GenreId;
            
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            string currentUserId = GetUserId();

            var model = await context.Games
                .Where(g => g.IsDeleted == false)
                .Where(g => g.GamersGames.Any(gg => gg.GamerId == currentUserId))
                .Select(g => new GameInfoViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ReleasedOn = g.ReleasedOn.ToString(DateFormat)
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            var entity = await context.Games.
                Where(g=>g.Id == id)
                .Include(g=>g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted == true)
            {
                throw new ArgumentException("Invalid id");
            }

            var currentUser=GetUserId();

            if (entity.GamersGames.Any(gg=>gg.GamerId == currentUser))
            {
                return RedirectToAction(nameof(All));
            }

            entity.GamersGames.Add(new GamerGame()
            {
                GamerId = currentUser,
                GameId = entity.Id
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            var entity = await context.Games.
                Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted == true)
            {
                throw new ArgumentException("Invalid id");
            }

            var currentUser = GetUserId();
            GamerGame? gamerGame = entity.GamersGames.FirstOrDefault(gg => gg.GamerId == currentUser);

            if (gamerGame != null)
            {
                entity.GamersGames.Remove(gamerGame);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id)
                .Where(g => g.IsDeleted == false)
                .AsNoTracking()
                .Select(g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(DateFormat),
                    Genre = g.Genre.Name,
                    Publisher = g.Publisher.UserName ?? string.Empty
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Games
               .Where(g => g.Id == id)
               .Where(g => g.IsDeleted == false)
               .AsNoTracking()
               .Select(g => new DeleteViewModel()
               {
                   Id = g.Id,
                   Title = g.Title,
                   Publisher = g.Publisher.UserName ?? string.Empty
               })
               .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await context.Games
                .Where(g => g.Id == id)
                .Where(g => g.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (game != null)
            {
                game.IsDeleted=true;

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
        private async Task<IEnumerable<object>> GetGenres()
        {
            return await context.Genres
                .AsNoTracking()
                .Select(t => new
                {
                     t.Id,
                     t.Name
                })
                .ToListAsync();
        }
        //private DateTime ParseReleaseOnDate(string dateString, ModelStateDictionary modelState)
        //{
        //    var releasedOn = DateTime.Now;

        //    if (!DateTime.TryParseExact(modelState.ReleasedOn,
        //        DateFormat,
        //        CultureInfo.InvariantCulture,
        //        DateTimeStyles.None,
        //        out releasedOn))
        //    {
        //        modelState
        //            .AddModelError(nameof(GameFormViewModel.ReleasedOn), $"Invalid date! Format must be: {DateFormat}");
        //    }

        //    return releasedOn;
        //}

    }
}
