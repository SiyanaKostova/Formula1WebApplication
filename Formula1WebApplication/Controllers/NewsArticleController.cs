using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	public class NewsArticleController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
