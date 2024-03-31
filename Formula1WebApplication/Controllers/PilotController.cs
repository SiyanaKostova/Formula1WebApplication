using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	public class PilotController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
