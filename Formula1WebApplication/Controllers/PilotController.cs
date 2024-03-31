using Formula1WebApplication.Core.Models.Pilot;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
    public class PilotController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> All()
        {
			var model = new AllPilotsQueryModel();

			return View(model);
		}

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var model = new PilotDetailsServiceModel();

            return View(model);
        }
    }
}
