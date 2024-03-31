using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	public class RaceController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
