using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Event;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	public class EventController : BaseController
	{
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int pageIndex = 1, string searchString = "", string sortOrder = "")
        {
			const int pageSize = 2;

            var events = await eventService.GetAllEventsAsync(pageIndex, pageSize, searchString, sortOrder);

            var model = new AllEventsQueryModel
            {
                Events = events,
                PageIndex = pageIndex,
                TotalPages = events.TotalPages,
                SearchString = searchString,
                SortOrder = sortOrder
            };

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
			var model = new EventServiceModel();

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
		public async Task<IActionResult> Delete(EventServiceModel model)
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
