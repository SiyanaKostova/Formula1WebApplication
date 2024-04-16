using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Statistics;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1WebApplication.Core.Services
{
	public class StatisticsService : IStatisticsService
	{
		private readonly IRepository repository;

        public StatisticsService(IRepository _repository)
        {
			repository = _repository;
        }

        public async Task<StatisticsServiceModel> TotalAsync()
		{
			int totalPilots = await repository.AllReadOnly<Pilot>()
				.CountAsync();

			int totalNewsArticles = await repository.AllReadOnly<NewsArticle>()
				.CountAsync();

			int totalEvents = await repository.AllReadOnly<Event>()
				.CountAsync();

			int totalRaces = await repository.AllReadOnly<Race>()
				.CountAsync();

			int totalOrganizers = await repository.AllReadOnly<Organizer>()
				.CountAsync();

			return new StatisticsServiceModel()
			{
				TotalPilots = totalPilots,
				TotalNewsArticles = totalNewsArticles,
				TotalEvents = totalEvents,
				TotalRaces = totalRaces,
				TotalOrganizers = totalOrganizers
			};
		}
	}
}
