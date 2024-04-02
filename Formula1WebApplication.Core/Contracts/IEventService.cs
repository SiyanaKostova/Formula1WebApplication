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
    }
}
