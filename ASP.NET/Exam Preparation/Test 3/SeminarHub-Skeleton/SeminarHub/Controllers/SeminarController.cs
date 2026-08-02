using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using SeminarHub.Models.Seminar;
using System;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;

        public SeminarController(SeminarHubDbContext context)
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
            var model = await data.Seminars.
                Select(s=>new SeminarAllViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Category.Name,
                    s.Organizer.UserName,
                    s.DateAndTime.ToString(DataConstants.DateFormat)
                    )).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormViewModel();
            model.Categories =await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel model)
        {
            DateTime dateTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime))
            {
                ModelState
                   .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = dateTime,
                Duration = model.Duration,
                CategoryId = model.CategoryId,
                OrganizerId = GetUserId()
            };

            await data.Seminars.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var model =await data.SeminarsParticipants.
                Select(sp=>new SeminarJoinedViewModel
                {
                    Topic=sp.Seminar.Topic,
                    Lecturer=sp.Seminar.Lecturer,
                    DateAndTime=sp.Seminar.DateAndTime.ToString(DataConstants.DateFormat),
                    Id=sp.Seminar.Id,
                    Organizer=sp.Seminar.Organizer.UserName

                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var model = await data.Seminars.
                Where(x => x.Id == id)
                .Include(x => x.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            var userId = GetUserId();

            if (!model.SeminarsParticipants.Any(s => s.ParticipantId == userId))
            {
                model.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    SeminarId = model.Id,
                    ParticipantId = userId
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var s = await data.Seminars.FindAsync(id);

            if (s == null)
            {
                return NotFound();
            }

            if (s.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model =await data.Seminars
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(s=> new SeminarFormViewModel()
                {
                    Topic=s.Topic,
                    Lecturer=s.Lecturer,
                    Details=s.Details,
                    DateAndTime=s.DateAndTime.ToString(DataConstants.DateFormat),
                    Duration=s.Duration,
                    CategoryId=s.CategoryId,
                    OrganizerId=GetUserId()
                })
                .FirstOrDefaultAsync();

            model.Categories =await GetCategories();

           
            return View(model); 
        }
        [HttpPost]
        public async Task<IActionResult>Edit(SeminarFormViewModel model,int id)
        {
            var seminar= await data.Seminars.FindAsync(id);

            if (seminar == null) 
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }
            var dateTime= DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime))
            {
                ModelState
                   .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(seminar);
            }

            seminar.Topic = model.Topic;
            seminar.Lecturer = model.Lecturer;
            seminar.Details = model.Details;
            seminar.DateAndTime = dateTime;
            seminar.Duration = model.Duration;
            seminar.CategoryId = model.CategoryId;

            model.Categories = await GetCategories();

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var s = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s=>s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return NotFound();
            }
            string userId = GetUserId();

            var ep = s.SeminarsParticipants
                .FirstOrDefault(sp => sp.ParticipantId == userId);

            if (ep == null)
            {
                return BadRequest();
            }

            s.SeminarsParticipants.Remove(ep);

            data.SaveChanges();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await data.Seminars.FindAsync(id);

            if (s == null)
            {
                return NotFound();
            }
            string userId= GetUserId();

            if (s.OrganizerId != userId)
            {
                return Unauthorized();
            }

            var model = await data.Seminars
                .Where(s => s.Id == id)
                .Select(s => new SeminarDetailsViewModel()
                {
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime,
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var s = await data.Seminars.FindAsync(id);

            if (s == null)
            {
                return NotFound();
            }
            string userId = GetUserId();

            if (s.OrganizerId != userId)
            {
                return Unauthorized();
            }

            data.Seminars.Remove(s);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model =await data.Seminars
                .Where(s => s.Id == id)
                .Select(s => new SeminarDetailsViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Organizer=s.OrganizerId,
                    DateAndTime = s.DateAndTime,
                    Duration = s.Duration,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    Details = s.Details
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }

}
