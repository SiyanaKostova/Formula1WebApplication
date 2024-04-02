using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.NewsArticle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Formula1WebApplication.Controllers
{
    public class NewsArticleController : BaseController
	{
        private readonly INewsArticleService newsArticleService;
        private readonly IOrganizerService organizerService;

        public NewsArticleController(
            INewsArticleService _newsArticleService,
            IOrganizerService _organizerService)
        {
            newsArticleService = _newsArticleService;
            organizerService = _organizerService;

        }

        [AllowAnonymous]
        public async Task<IActionResult> All(string sortOrder, string searchString, int? pageIndex)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

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
			var model = new NewsArticleServiceModel();

			return View(model);
		}

        [HttpPost]
        public async Task<IActionResult> Add(NewsArticleServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var organizerId = await organizerService.GetOrganizerIdAsync(User.Id());

            if (organizerId == null)
            {
                return NotFound();
            }

            await newsArticleService.AddAsync(model, organizerId.Value);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await newsArticleService.HasOrganizerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await newsArticleService.GetNewsArticleServiceModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewsArticleServiceModel model)
        {
            if (await newsArticleService.HasOrganizerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await newsArticleService.EditAsync(id, model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await newsArticleService.HasOrganizerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var newsArticle = await newsArticleService.GetDetailsAsync(id);

            var model = new NewsArticleServiceModel()
            {
                Id = id,
                Title = newsArticle.Title,
                Description = newsArticle.Description,
                ImageUrl = newsArticle.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewsArticleServiceModel model)
        {
            if (await newsArticleService.HasOrganizerWithIdAsync(model.Id, User.Id()) == false)
            {
                return Unauthorized();
            }

            await newsArticleService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
