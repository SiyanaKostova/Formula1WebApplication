using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
