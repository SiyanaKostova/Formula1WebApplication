using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Data.SeedDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.SeedDb.Configurations
{
    internal class NewsArticleConfiguration : IEntityTypeConfiguration<NewsArticle>
    {
        public void Configure(EntityTypeBuilder<NewsArticle> builder)
        {
            var data = new SeedData();

            builder.HasData(new NewsArticle[] { data.TheStrategist, data.NotWhereIExpectedToBe, data.HinchsHeroes });
        }
    }
}
