using System.ComponentModel.DataAnnotations;

namespace Formula1WebApplication.Core.Models.NewsArticle
{
    public class AllNewsArticlesQueryModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public List<NewsArticleServiceModel> Articles { get; set; } = new List<NewsArticleServiceModel>();
    }
}
