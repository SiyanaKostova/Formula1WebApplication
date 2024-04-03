using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Race;
using Formula1WebApplication.Core.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Details(int id)
        {
            var raceDetails = await raceService.GetDetailsAsync(id);

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
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new RaceServiceModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RaceServiceModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new RaceServiceModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RaceServiceModel model)
        {
            return RedirectToAction(nameof(All));
        }
    }
}
