using Formula1WebApplication.Core.Contracts;
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
        public async Task<IActionResult> All(string searchTerm, string nationality, string team, string sortOrder, int pageIndex = 1, int pageSize = 10)
        {
            var pilotModel = await pilotService.GetAllPilotsAsync(searchTerm, nationality, team, sortOrder, pageIndex, pageSize);

            return View(pilotModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var pilotDetails = await pilotService.GetDetailsAsync(id);

            if (pilotDetails == null)
            {
                return NotFound(); 
            }

            return View(pilotDetails);
        }
    }
}
