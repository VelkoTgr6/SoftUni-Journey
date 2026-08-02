using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext data;

        public BookController(LibraryDbContext context)
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
            var model= await data.Books
                .AsNoTracking()
                .Select(b=>new BookInfoViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    Category=b.Category.Name,
                    ImageUrl = b.ImageUrl
                }).ToListAsync();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookFormViewModel();
            model.Categories=await GetCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Add(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories= await GetCategoriesAsync();
                return View(model);
            }

            var entity = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = (decimal)model.Rating,
                CategoryId = model.CategoryId
            };

            data.Books.Add(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model =await data.Books
                .AsNoTracking()
                .Select(b => new BookInfoViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Category = b.Category.Name,
                    ImageUrl= b.ImageUrl,
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>AddToCollection(int id)
        {
            var book = await data.Books
                .Include(b => b.UserBooks)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return BadRequest();
            }

            var collector = data.IdentityUsersBooks
                .Select(isb => isb.ColectorId);

            if (data.IdentityUsersBooks.Any(isb=>isb.BookId != id))
            {
                var model = await data.IdentityUsersBooks
               .Select(m => new IdentityUserBook()
               {
                   Book = book,
                   ColectorId = GetUserId()
               }).ToListAsync();
            }

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult>RemoveFromCollection(int id)
        {
            var book = await data.Books
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (book == null) 
            {
                return BadRequest();
            }

            data.Books.Remove(book);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Mine));
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
    
}

