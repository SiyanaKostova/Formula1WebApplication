﻿using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Race;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Formula1WebApplication.Core.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRepository repository;

        public RaceService(IRepository _repository)
        {
            repository = _repository;
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
    }
}
