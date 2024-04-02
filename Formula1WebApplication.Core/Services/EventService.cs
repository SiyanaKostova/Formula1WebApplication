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

        public async Task AddAsync(EventServiceModel model, int organizerId)
        {
            var eventToAdd = new Event
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Location = model.Location,
                OrganizerId = organizerId,
                Date = model.Date
            };

            await repository.AddAsync(eventToAdd);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int eventId)
        {
            await repository.DeleteAsync<Event>(eventId);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int eventId, EventServiceModel model)
        {
            var eventToEdit = await repository.GetByIdAsync<Event>(eventId);

            if (eventToEdit != null)
            {
                eventToEdit.Name = model.Name;
                eventToEdit.Description = model.Description;
                eventToEdit.ImageUrl = model.ImageUrl;
                eventToEdit.Location = model.Location;
                eventToEdit.Date = model.Date;

                await repository.SaveChangesAsync();
            }
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

        public async Task<EventServiceModel> GetDetailsAsync(int eventId)
        {
            var eventDetails = await repository.AllReadOnly<Event>()
                .Where(e => e.Id == eventId)
                .Select(e => new EventServiceModel
                {
                    Id = e.Id,
                    ImageUrl = e.ImageUrl,
                    Date = e.Date,
                    Description = e.Description,
                    Location = e.Location,
                    Name = e.Name
                })
                .FirstOrDefaultAsync();

            return eventDetails;
        }

        public async Task<EventServiceModel?> GetEventServiceModelByIdAsync(int id)
        {
            var eventModel = await repository.AllReadOnly<Event>()
                .Where(e => e.Id == id)
                .Select(e => new EventServiceModel()
                {
                    Id= e.Id,
                    ImageUrl = e.ImageUrl,
                    Date = e.Date,
                    Description = e.Description,
                    Location = e.Location,
                    Name = e.Name
                })
                .FirstOrDefaultAsync();

            return eventModel;
        }

        public async Task<bool> HasOrganizerWithIdAsync(int eventId, string userId)
        {
            return await repository.AllReadOnly<Event>()
                .AnyAsync(a => a.Id == eventId && a.Organizer.UserId == userId);
        }
    }
}
