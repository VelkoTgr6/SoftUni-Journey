using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models.Product;

namespace MVCIntroDemo.Controllers
{
	public class ProductController : Controller
	{
		private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
		{
			new ProductViewModel()
			{
				Id = 1,
				Name = "Cheese",
				Price = 7.00
			},
			new ProductViewModel()
			{
				Id = 2,
				Name = "Ham",
				Price = 5.50
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Bread",
				Price = 1.50
			},
		};
		public IActionResult Index()
		{
			return View();
		}
		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
            if (keyword != null)
            {
                var foundProducts = products
                    .Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

				return View(foundProducts);
            }

			return View(products);
		}

		public IActionResult ById(int Id)
		{
			var product = products.FirstOrDefault(p => p.Id == Id);

			if (product == null)
			{
				return BadRequest();
			}

			return View(product);
		}

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            return Content(ProductTextBuilder());
        }

        public IActionResult AllAsTextFile()
        {
			Response.Headers.Add(HeaderNames.ContentDisposition,@"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(ProductTextBuilder()), "text/plain");
        }

        private string ProductTextBuilder()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in products)
            {
                sb.AppendLine($"Product {item.Id}: {item.Name} - {item.Price} lv.");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
