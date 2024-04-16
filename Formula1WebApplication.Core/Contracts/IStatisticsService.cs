using Formula1WebApplication.Core.Models.Statistics;

namespace Formula1WebApplication.Core.Contracts
{
	public interface IStatisticsService
	{
		Task<StatisticsServiceModel> TotalAsync();
	}
}
