using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Organizer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Formula1WebApplication.Core.Constants.MessageConstants;

namespace Formula1WebApplication.Controllers
{
    public class OrganizerController : BaseController
	{
        private readonly IOrganizerService organizerService;

        public OrganizerController(IOrganizerService _organizerService)
        {
            organizerService = _organizerService;
        }

        [HttpGet]
		public IActionResult Become()
		{
			var model = new BecomeOrganizerFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeOrganizerFormModel model)
		{
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Id(); 

            if (await organizerService.IsUserAlreadyOrganizerAsync(userId))
            {
                ModelState.AddModelError(string.Empty, AlreadyOrganizerMessage);
                return View(model);
            }

            if (await organizerService.IsPhoneNumberAlreadyUsedAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(BecomeOrganizerFormModel.PhoneNumber), PhoneExistsMessage);
                return View(model);
            }

            var success = await organizerService.BecomeOrganizerAsync(userId, model.PhoneNumber);

            if (success)
            {
                return RedirectToAction(nameof(NewsArticleController.All), "NewsArticle");
            }

            ModelState.AddModelError(string.Empty, "An unknown error occurred. Please try again.");
            return View(model);
        }
    }
}
