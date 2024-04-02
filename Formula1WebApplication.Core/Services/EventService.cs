using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Event;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Formula1WebApplication.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository repository;

        public EventService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<PaginatedList<EventServiceModel>> GetAllEventsAsync(int pageIndex, int pageSize, string searchString, string sortOrder)
        {
            var query = repository.All<Event>()
           .Select(e => new EventServiceModel
           {
               Id = e.Id,
               Name = e.Name,
               Description = e.Description,
               ImageUrl = e.ImageUrl,
               Location = e.Location,
               Date = e.Date
           });

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.Name.Contains(searchString) || e.Location.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(e => e.Name);
                    break;
                case "name":
                    query = query.OrderBy(e => e.Name);
                    break;
                case "newest":
                    query = query.OrderByDescending(e => e.Id);
                    break;
                default:
                    query = query.OrderBy(e => e.Id);
                    break;
            }

            var count = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<EventServiceModel>(items, count, pageIndex, pageSize);
        }
    }
}
