using Formula1WebApplication.Core.Models.Pilot;

namespace Formula1WebApplication.Core.Contracts
{
    public interface IPilotService
    {
        Task<AllPilotsQueryModel> GetAllPilotsAsync(string searchTerm,
                                                    string nationalityFilter,
                                                    string teamFilter,
                                                    string sortOrder,
                                                    int pageIndex,
                                                    int pageSize);

        Task<PilotDetailsServiceModel> GetDetailsAsync(int pilotId);
    }
}
