using Formula1WebApplication.Core.Models.Race;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
    public class RaceController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> All()
        {
			var model = new AllRacesQueryModel();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
        {
            var model = new AllRacesQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var model = new RaceDetailsServiceModel();

            return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new RaceFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(RaceFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new RaceFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RaceFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new RaceFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RaceDetailsViewModel model)
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
