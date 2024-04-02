using Formula1WebApplication.Infrastructure.Pagination;

namespace Formula1WebApplication.Core.Models.Event
{
    public class AllEventsQueryModel
    {
        public PaginatedList<EventServiceModel> Events { get; set; } 
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
    }
}
