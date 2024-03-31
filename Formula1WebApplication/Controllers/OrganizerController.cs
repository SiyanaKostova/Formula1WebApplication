using Formula1WebApplication.Core.Models.Organizer;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	public class OrganizerController : BaseController
	{
		[HttpGet]
		[HttpPost]
		public async Task<IActionResult> Become()
		{
			var model = new BecomeOrganizerFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeOrganizerFormModel model)
		{
			return RedirectToAction(nameof(PilotController.All), "Pilot");
		}
	}
}
