using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Areas.Admin.Controllers
{
	public class HomeController : AdminBaseController
    {
		public IActionResult DashBoard()
		{
			return View();
		}
	}
}
