using Formula1WebApplication.Core.Models.NewsArticle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
    public class NewsArticleController : BaseController
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = new AllNewsArticlesQueryModel();

			return View(model);
		}

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var model = new NewsArticleDetailsServiceModel();

            return View(model);
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
