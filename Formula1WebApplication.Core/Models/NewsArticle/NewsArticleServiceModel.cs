using System.ComponentModel.DataAnnotations;
using static Formula1WebApplication.Core.Constants.MessageConstants;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Core.Models.NewsArticle
{
    public class NewsArticleServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NewsArticleTitleMaxLength,
        ErrorMessage = MaxLengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NewsArticleDescriptionMaxLength,
        MinimumLength = NewsArticleDescriptionMinLength,
        ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
