using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Pilot;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1WebApplication.Core.Services
{
    public class PilotService : IPilotService
    {
        private readonly IRepository repository;

        public PilotService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<AllPilotsQueryModel> GetAllPilotsAsync(string searchTerm, string nationalityFilter, string teamFilter, string sortOrder)
        {
            var pilotQuery = repository.All<Pilot>().AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                pilotQuery = pilotQuery.Where(p => p.FirstName.Contains(searchTerm) || p.LastName.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(nationalityFilter))
            {
                pilotQuery = pilotQuery.Where(p => p.Nationality == nationalityFilter);
            }

            if (!string.IsNullOrEmpty(teamFilter))
            {
                pilotQuery = pilotQuery.Where(p => p.TeamName == teamFilter);
            }

            switch (sortOrder)
            {
                case "firstName_asc":
                    pilotQuery = pilotQuery.OrderBy(p => p.FirstName);
                    break;
                case "firstName_desc":
                    pilotQuery = pilotQuery.OrderByDescending(p => p.FirstName);
                    break;
                default:
                    pilotQuery = pilotQuery.OrderBy(p => p.FirstName);
                    break;
            }

            var pilots = await pilotQuery
                .Select(p => new PilotServiceModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Nationality = p.Nationality,
                    TeamName = p.TeamName,
                    Biography = p.Biography,
                    ImagePath = p.ImagePath
                })
                .ToListAsync();

            return new AllPilotsQueryModel
            {
                Pilots = pilots,
                SearchTerm = searchTerm,
                NationalityFilter = nationalityFilter,
                TeamFilter = teamFilter,
                SortOrder = sortOrder
            };
        }
    }
}
