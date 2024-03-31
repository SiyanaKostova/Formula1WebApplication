using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Infrastructure.Data.Models
{
    public class NewsArticle
    {
        [Key]
        [Comment("Unique identifier for news article")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NewsArticleTitleMaxLength)]
        [Comment("The title of the article")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(NewsArticleDescriptionMaxLength)]
        [Comment("Detailed description or content of the article")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("URL to an image related to the news article")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("News Article Organizer Id")]
        public int OrganizerId { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public Organizer Organizer { get; set; } = null!;
    }
}
