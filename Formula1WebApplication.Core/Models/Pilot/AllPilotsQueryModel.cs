using Formula1WebApplication.Infrastructure.Pagination;

namespace Formula1WebApplication.Core.Models.Pilot
{
    public class AllPilotsQueryModel
    {
        public PaginatedList<PilotAllServiceModel> Pilots { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
        public string NationalityFilter { get; set; } = string.Empty;
        public string TeamFilter { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
