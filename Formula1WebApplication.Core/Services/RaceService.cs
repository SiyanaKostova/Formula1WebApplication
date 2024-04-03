using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Event;
using Formula1WebApplication.Core.Models.NewsArticle;
using Formula1WebApplication.Core.Models.Race;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Formula1WebApplication.Core.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRepository repository;

        public RaceService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(RaceServiceModel model, int organizerId)
        {
            var raceToAdd = new Race
            {
                Name = model.Name,
                CircuitInfo = model.CircuitInfo,
                Date = model.Date,
                Location = model.Location,
                Laps = model.Laps,
                ImageUrl = model.ImageUrl,
                OrganizerId = organizerId
            };

            await repository.AddAsync(raceToAdd);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int raceId, RaceServiceModel model)
        {
            var race = await repository.GetByIdAsync<Race>(raceId);

            if (race != null)
            {
                race.Name = model.Name;
                race.CircuitInfo = model.CircuitInfo;
                race.Date = model.Date;
                race.Location = model.Location;
                race.Laps = model.Laps;
                race.ImageUrl = model.ImageUrl;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<PaginatedList<RaceServiceModel>> GetAllRacesAsync(string searchString, string sortOrder, int pageIndex, int pageSize)
        {
            var racesQuery = repository.All<Race>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                racesQuery = racesQuery.Where(r =>
                    r.Name.Contains(searchString) || r.Location.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name":
                    racesQuery = racesQuery.OrderBy(r => r.Name);
                    break;
                case "name_desc":
                    racesQuery = racesQuery.OrderByDescending(r => r.Name);
                    break;
                case "laps":
                    racesQuery = racesQuery.OrderBy(r => r.Laps);
                    break;
                case "laps_desc":
                    racesQuery = racesQuery.OrderByDescending(r => r.Laps);
                    break;
                case "newest":
                default:
                    racesQuery = racesQuery.OrderByDescending(r => r.Id);
                    break;
            }

            var count = await racesQuery.CountAsync();

            var items = await racesQuery
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new RaceServiceModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Location = r.Location,
                    Date = r.Date,
                    ImageUrl = r.ImageUrl,
                    Laps = r.Laps,
                    CircuitInfo = r.CircuitInfo
                })
                .ToListAsync();

            return new PaginatedList<RaceServiceModel>(items, count, pageIndex, pageSize);
        }

        public async Task<RaceServiceModel> GetDetailsAsync(int raceId)
        {
            var raceDetails = await repository.AllReadOnly<Race>()
                .Where(r => r.Id == raceId)
                .Select(r => new RaceServiceModel
                {
                    Id = r.Id,
                    Laps = r.Laps,
                    Name = r.Name,
                    Location = r.Location,
                    Date = r.Date,
                    ImageUrl = r.ImageUrl,
                    CircuitInfo = r.CircuitInfo
                })
                .FirstOrDefaultAsync();

            return raceDetails;
        }

        public async Task<RaceServiceModel?> GetRaceServiceModelByIdAsync(int id)
        {
            var race = await repository.AllReadOnly<Race>()
                           .Where(r => r.Id == id)
                            .Select(r => new RaceServiceModel
                            {
                                Id = r.Id,
                                Laps = r.Laps,
                                Name = r.Name,
                                Location = r.Location,
                                Date = r.Date,
                                ImageUrl = r.ImageUrl,
                                CircuitInfo = r.CircuitInfo
                            })
                            .FirstOrDefaultAsync();

            return race;
        }

        public async Task<bool> HasOrganizerWithIdAsync(int raceId, string userId)
        {
            return await repository.AllReadOnly<Race>()
                            .AnyAsync(r => r.Id == raceId && r.Organizer.UserId == userId);
        }
    }
}
