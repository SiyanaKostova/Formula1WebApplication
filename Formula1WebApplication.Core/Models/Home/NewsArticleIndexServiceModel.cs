namespace Formula1WebApplication.Core.Models.Home
{
    public class NewsArticleIndexServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
