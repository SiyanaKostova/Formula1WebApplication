using Formula1WebApplication.Core.Models.Race;
using Formula1WebApplication.Infrastructure.Pagination;

namespace Formula1WebApplication.Core.Contracts
{
    public interface IRaceService
    {
        Task<PaginatedList<RaceServiceModel>> GetAllRacesAsync(string searchString,
                                                               string sortOrder,
                                                               int pageIndex,
                                                               int pageSize);
        Task<RaceServiceModel> GetDetailsAsync(int raceId);

        Task AddAsync(RaceServiceModel model, int organizerId);

        Task EditAsync(int raceId, RaceServiceModel model);

        Task<bool> HasOrganizerWithIdAsync(int raceId, string userId);

        Task<RaceServiceModel?> GetRaceServiceModelByIdAsync(int id);
    }
}
