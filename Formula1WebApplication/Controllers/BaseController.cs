using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
	}
}
