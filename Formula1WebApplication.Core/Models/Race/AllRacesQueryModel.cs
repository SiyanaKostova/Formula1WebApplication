using Formula1WebApplication.Infrastructure.Pagination;

namespace Formula1WebApplication.Core.Models.Race
{
    public class AllRacesQueryModel
    {
        public PaginatedList<RaceServiceModel> Races { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
    }
}
