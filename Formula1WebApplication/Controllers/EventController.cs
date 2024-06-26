﻿using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Extensions;
using Formula1WebApplication.Core.Models.Event;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Formula1WebApplication.Core.Constants.MessageConstants;

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
            var userId = User.Id();

            var events = await eventService.GetMyEventsAsync(userId);

            return View(events);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			var eventDetails = await eventService.GetDetailsAsync(id);

            if (information != eventDetails.GetEventDetails())
            {
                return StatusCode(500);
            }

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

            TempData[UserMessageSuccess] = "You have successfully added an Event!";

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
            if (await eventService.HasOrganizerWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                TempData[UserMessageError] = "You were not able to edit this Event!";

                return BadRequest();
            }

            var model = await eventService.GetEventServiceModelByIdAsync(id);

            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EventServiceModel model)
		{
            if (await eventService.HasOrganizerWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await eventService.EditAsync(id, model);

            TempData[UserMessageSuccess] = "You have successfully edited the Event!";

            return RedirectToAction(nameof(Details), new { id, information = model.GetEventDetails() });
        }

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
            if (await eventService.HasOrganizerWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
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
            if (await eventService.HasOrganizerWithIdAsync(model.Id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await eventService.DeleteAsync(model.Id);

            TempData[UserMessageSuccess] = "You have deleted the Event successfully!";

            return RedirectToAction(nameof(All));
        }

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
            var result = await eventService.JoinEventAsync(id, User.Id());

            if (!result)
            {
                return BadRequest();
            }

            TempData[UserMessageSuccess] = "You have joined the Event successfully!";

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var success = await eventService.LeaveEventAsync(id, User.Id());

            if (!success)
            {
                return NotFound();
            }

            TempData[UserMessageSuccess] = "You have left the Event successfully!";

            return RedirectToAction(nameof(Mine)); 
        }
    }
}
