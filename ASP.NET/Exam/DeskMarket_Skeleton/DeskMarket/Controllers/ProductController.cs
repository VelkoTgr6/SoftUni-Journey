using DeskMarket.Constants;
using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models.Category;
using DeskMarket.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace DeskMarket.Controllers
{

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUserId =await GetUserIdAsync();

            var products = await context.Products
                .Include(p => p.ProductsClients)
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductInfoViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    IsSeller = p.SellerId == currentUserId,
                    HasBought = p.ProductsClients.Any(pc => pc.ClientId == currentUserId)
                })
                .AsNoTracking()
                .ToListAsync();


            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var product = new ProductFormViewModel();
            product.Categories = await GetCategories();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            if (!TryParseDate(model.AddedOn, out DateTime addedOn))
            {
                ModelState
                    .AddModelError(nameof(model.AddedOn), $"Invalid date! Format must be: {ModelConstants.DateFormat}");
                model.Categories = await GetCategories();

                return View(model);
            }

            var currentUserId=await GetUserIdAsync();

            var entity = new Product()
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                AddedOn = addedOn,
                CategoryId = model.CategoryId,
                SellerId = currentUserId,
            };

            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var currentUserId = await GetUserIdAsync();

            var products = await context.Products
                .Where(p => p.IsDeleted == false)
                .Where(p => p.ProductsClients.Any(c => c.ClientId == currentUserId))
                .AsNoTracking()
                .Select(p => new ProductCartViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                })
                .ToListAsync();

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var entity = await context.Products
                .Where(p => p.Id == id)
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                return RedirectToAction(nameof(Cart));
            }

            var currentUserId = await GetUserIdAsync();

            if (entity.ProductsClients.Any(pc => pc.ClientId == currentUserId))
            {
                return RedirectToAction(nameof(Cart));
            }

            entity.ProductsClients.Add(new ProductClient()
            {
                ProductId = entity.Id,
                ClientId = currentUserId,
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var entity = await context.Products
                .Where(p => p.Id == id)
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                return RedirectToAction(nameof(Cart));
            }

            var currentUserId = await GetUserIdAsync();

            var productClient = entity.ProductsClients.FirstOrDefault(pc=>pc.ClientId == currentUserId);

            if (productClient != null)
            {
                entity.ProductsClients.Remove(productClient);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            var currentUserId= await GetUserIdAsync();

            var product = await context.Products
                .Where (p => p.Id == id)
                .AsNoTracking()
                .Select(p=> new ProductDetailsViewModel() 
                { 
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    CategoryName = p.Category.Name,
                    AddedOn=p.AddedOn.ToString(ModelConstants.DateFormat),
                    Seller=p.Seller.UserName ?? string.Empty,
                    HasBought = p.ProductsClients.Any(pc => pc.ClientId == currentUserId)
                })
                .FirstOrDefaultAsync();

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Products
                .Where(p => p.Id == id)
                .Where(p=>p.IsDeleted == false)
                .AsNoTracking()
                .Select(p=> new ProductFormViewModel()
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    AddedOn = p.AddedOn.ToString(ModelConstants.DateFormat),
                    SellerId = p.SellerId,
                    CategoryId = p.Category.Id
                })
                .FirstOrDefaultAsync();

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductFormViewModel model,int id)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            if (!TryParseDate(model.AddedOn,out DateTime addedOn))
            {
                ModelState
                    .AddModelError(nameof(model.AddedOn), $"Invalid date! Format must be: {ModelConstants.DateFormat}");
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = await context.Products.FindAsync(id);

            if (entity == null || entity.IsDeleted)
            {
                return RedirectToAction(nameof(Index));
            }

            var currentUser = await GetUserIdAsync();

            if (entity.SellerId != currentUser)
            {
                return RedirectToAction(nameof(Index));
            }

            entity.ProductName = model.ProductName;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.AddedOn = addedOn;
            entity.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            var product = await context.Products
                .Where(p =>p.Id == id)
                .Where(p=>p.IsDeleted == false)
                .AsNoTracking()
                .Select(p=>new ProductDeleteViewModel() 
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Seller = p.Seller.UserName ?? string.Empty,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var product = await context.Products
                .Where(g => g.Id == id)
                .Where(g => g.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                product.IsDeleted = true;

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private Task<string> GetUserIdAsync()
        {
            return Task.FromResult(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
        }

        private async Task<IList<CategoryViewModel>> GetCategories()
        { 
            return await context.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel()
                {
                    Id=t.Id,
                    Name=t.Name
                })
                .ToListAsync();
        }
        private bool TryParseDate(string input, out DateTime addedOn)
        {
            return DateTime.TryParseExact(
                input,
                ModelConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out addedOn
            );
        }

    }
}
