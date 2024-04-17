using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Extensions;
using Formula1WebApplication.Core.Models.Race;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Formula1WebApplication.Controllers
{
    public class RaceController : BaseController
	{
        private readonly IRaceService raceService;
        private readonly IOrganizerService organizerService;

        public RaceController(
            IRaceService _raceService,
            IOrganizerService _organizerService)
        {
            raceService = _raceService;
            organizerService = _organizerService;
        }

        [HttpGet]
		public async Task<IActionResult> All(string searchString, string sortOrder, int pageIndex = 1)
        {
            const int pageSize = 2
                ;
            var races = await raceService.GetAllRacesAsync(searchString, sortOrder, pageIndex, pageSize);

            var model = new AllRacesQueryModel
            {
                Races = races,
                SearchString = searchString,
                SortOrder = sortOrder,
                PageIndex = pageIndex,
                TotalPages = races.TotalPages
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            var raceDetails = await raceService.GetDetailsAsync(id);

            if (information != raceDetails.GetRaceDetails())
            {
                return StatusCode(500);
            }

            if (raceDetails == null)
            {
                return NotFound();
            }

            return View(raceDetails);
        }

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new RaceServiceModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(RaceServiceModel model)
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

            await raceService.AddAsync(model, organizerId.Value);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await raceService.HasOrganizerWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                return BadRequest();
            }

            var model = await raceService.GetRaceServiceModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RaceServiceModel model)
        {
            if (await raceService.HasOrganizerWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                return BadRequest();
            }


            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await raceService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id, information = model.GetRaceDetails() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await raceService.HasOrganizerWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var race = await raceService.GetDetailsAsync(id);

            var model = new RaceServiceModel()
            {
                Id = id,
                Name = race.Name,
                CircuitInfo = race.CircuitInfo,
                Laps = race.Laps,
                Location = race.Location,
                Date = race.Date,
                ImageUrl = race.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RaceServiceModel model)
        {
            if (await raceService.HasOrganizerWithIdAsync(model.Id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await raceService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
