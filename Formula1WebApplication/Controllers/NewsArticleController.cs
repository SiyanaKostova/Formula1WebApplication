using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.NewsArticle;
using Formula1WebApplication.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
    public class NewsArticleController : BaseController
	{
        private readonly INewsArticleService newsArticleService;

        public NewsArticleController(INewsArticleService _newsArticleService)
        {
            newsArticleService = _newsArticleService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(string sortOrder, string searchString, int? pageIndex)
        {
            const int pageSize = 2;

            int currentPageIndex = pageIndex ?? 1;

            var articles = await newsArticleService.GetArticlesAsync(sortOrder, searchString, currentPageIndex, pageSize);

            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var articleDetails = await newsArticleService.GetDetailsAsync(id);

            if (articleDetails == null)
            {
                return NotFound();
            }

            return View(articleDetails);
        }

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new NewsArticleFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(NewsArticleFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new NewsArticleFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewsArticleFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new NewsArticleFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewsArticleDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }
    }
}
