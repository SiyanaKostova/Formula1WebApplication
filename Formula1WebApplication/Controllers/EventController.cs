using Formula1WebApplication.Core.Models.Event;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	public class EventController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = new AllEventsQueryModel();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			var model = new AllEventsQueryModel();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details()
		{
			var model = new EventDetailsServiceModel();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new EventFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(EventFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var model = new EventFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EventFormModel model)
		{
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var model = new EventFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(EventDetailsViewModel model)
		{
			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
			return RedirectToAction(nameof(Mine));
		}

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
