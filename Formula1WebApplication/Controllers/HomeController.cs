using Formula1WebApplication.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
    public class HomeController : BaseController
	{
        private readonly ILogger<HomeController> _logger;
        private readonly INewsArticleService newsArticleService;

        public HomeController(
            ILogger<HomeController> logger,
            INewsArticleService _newsArticleService)
        {
            _logger = logger;
            newsArticleService = _newsArticleService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await newsArticleService.LastThreeNewsArticlesAsync();

            return View(model);
        }

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 404)
			{
				return View("Error404");
			}

			if (statusCode == 500)
			{
				return View("Error500");
			}

			return View();
		}
	}
}
