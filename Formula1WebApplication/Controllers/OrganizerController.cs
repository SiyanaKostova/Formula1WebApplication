using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	public class OrganizerController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
