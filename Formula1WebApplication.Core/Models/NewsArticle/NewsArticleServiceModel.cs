using System.ComponentModel.DataAnnotations;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;
using static Formula1WebApplication.Core.Constants.MessageConstants;

namespace Formula1WebApplication.Core.Models.NewsArticle
{
    public class NewsArticleServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NewsArticleTitleMaxLength,
        ErrorMessage = LengthMessage)]
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
