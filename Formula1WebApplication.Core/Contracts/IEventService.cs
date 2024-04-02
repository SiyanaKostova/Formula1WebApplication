using Formula1WebApplication.Core.Models.Event;
using Formula1WebApplication.Infrastructure.Pagination;

namespace Formula1WebApplication.Core.Contracts
{
    public interface IEventService
    {
        Task<PaginatedList<EventServiceModel>> GetAllEventsAsync(int pageIndex,
                                                                 int pageSize,
                                                                 string searchString,
                                                                 string sortOrder);
        Task<EventServiceModel> GetDetailsAsync(int eventId);

        Task AddAsync(EventServiceModel model, int organizerId);

        Task EditAsync(int eventId, EventServiceModel model);

        Task<bool> HasOrganizerWithIdAsync(int eventId, string userId);

        Task<EventServiceModel?> GetEventServiceModelByIdAsync(int id);

        Task DeleteAsync(int eventId);

        Task<bool> JoinEventAsync(int eventId, string userId);

        Task<bool> IsJoinedByIUserWithIdAsync(int eventId, string userId);

        Task<IEnumerable<EventServiceModel>> GetMyEventsAsync(string userId);
    }
}
