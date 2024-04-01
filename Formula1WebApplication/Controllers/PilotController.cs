using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Pilot;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
    public class PilotController : BaseController
	{
        private readonly IPilotService pilotService;

        public PilotController(IPilotService _pilotService)
        {
            pilotService = _pilotService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string searchTerm, string nationality, string team, string sortOrder)
        {
            var queryModel = await pilotService.GetAllPilotsAsync(searchTerm, nationality, team, sortOrder);
            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var model = new PilotDetailsServiceModel();

            return View(model);
        }
    }
}
