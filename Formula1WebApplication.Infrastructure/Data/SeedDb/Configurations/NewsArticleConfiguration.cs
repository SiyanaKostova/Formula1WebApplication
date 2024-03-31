using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.Data.SeedDb.Configurations
{
    internal class NewsArticleConfiguration : IEntityTypeConfiguration<NewsArticle>
    {
        public void Configure(EntityTypeBuilder<NewsArticle> builder)
        {
            builder
            .HasOne(n => n.Organizer)
            .WithMany(o => o.NewsArticles)
            .HasForeignKey(n => n.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new NewsArticle[] { data.TheStrategist, data.NotWhereIExpectedToBe, data.HinchsHeroes });
        }
    }
}
