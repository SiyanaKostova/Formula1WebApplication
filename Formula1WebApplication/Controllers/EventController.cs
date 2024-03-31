using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	public class EventController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
