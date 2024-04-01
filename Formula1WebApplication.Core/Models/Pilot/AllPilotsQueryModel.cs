namespace Formula1WebApplication.Core.Models.Pilot
{
    public class AllPilotsQueryModel
    {
        public IEnumerable<PilotServiceModel> Pilots { get; set; } = new List<PilotServiceModel>();
        public string SearchTerm { get; set; } = string.Empty;
        public string NationalityFilter { get; set; } = string.Empty;
        public string TeamFilter { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
    }
}
