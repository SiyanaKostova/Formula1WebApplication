using Formula1WebApplication.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Formula1WebApplication.Areas.Admin.Controllers
{
	public class StatisticsController : AdminBaseController
	{
		private readonly IStatisticsService statisticsService;

		public StatisticsController(IStatisticsService statisticsService)
		{
			this.statisticsService = statisticsService;
		}

		[HttpGet]
		public async Task<IActionResult> Statistics()
		{
			var statistics = await statisticsService.TotalAsync();

			return View(statistics); 
		}
	}
}
