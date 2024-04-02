using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Event;
using Formula1WebApplication.Core.Models.NewsArticle;
using Formula1WebApplication.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Formula1WebApplication.Controllers
{
    public class EventController : BaseController
	{
        private readonly IEventService eventService;
        private readonly IOrganizerService organizerService;

        public EventController(
            IEventService _eventService,
            IOrganizerService _organizerService)
        {
            eventService = _eventService;
            organizerService = _organizerService;
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
		public async Task<IActionResult> Details(int id)
		{
			var eventDetails = await eventService.GetDetailsAsync(id);

			if (eventDetails == null)
			{
				return NotFound();
			}

			return View(eventDetails);
		}

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventServiceModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventServiceModel model)
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

            await eventService.AddAsync(model, organizerId.Value);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
            if (await eventService.HasOrganizerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await eventService.GetEventServiceModelByIdAsync(id);

            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EventServiceModel model)
		{
            if (await eventService.HasOrganizerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }


            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await eventService.EditAsync(id, model);

            return RedirectToAction(nameof(All));
        }

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
            if (await eventService.HasOrganizerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var eventToDelete = await eventService.GetDetailsAsync(id);

            var model = new EventServiceModel()
            {
                Id = id,
                Name = eventToDelete.Name,
                Date = eventToDelete.Date,
                Description = eventToDelete.Description,
                ImageUrl = eventToDelete.ImageUrl,
                Location = eventToDelete.Location
            };

            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Delete(EventServiceModel model)
		{
            if (await eventService.HasOrganizerWithIdAsync(model.Id, User.Id()) == false)
            {
                return Unauthorized();
            }

            await eventService.DeleteAsync(model.Id);

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
