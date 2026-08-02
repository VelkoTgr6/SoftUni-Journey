using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Text_Splitter.Models;

namespace Text_Splitter.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		[HttpPost]
		public IActionResult Split(TextViewModel model)
		{
			if (model.Text == null)
			{
				ViewBag.ErrorMessage = "The Text field is required";
				return View(nameof(Index), model);
			} 
			if (model.Text.Length < 2 || model.Text.Length > 30)
			{
				ViewBag.ErrorMessage =
					"The field Text must be a string with a minimum length of 2 and maximum length of 30";
				return View(nameof(Index), model);
			}
			var splitTextArray = model.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();


			model.SplitText = string.Join(Environment.NewLine, splitTextArray);

			return RedirectToAction(nameof(Index), model);

		}
		public IActionResult Index(TextViewModel model)
		{
			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
