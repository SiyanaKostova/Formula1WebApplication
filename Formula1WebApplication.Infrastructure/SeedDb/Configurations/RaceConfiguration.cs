using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Data.SeedDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.SeedDb
{
    internal class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            var data = new SeedData();

            builder.HasData(new Race[] {data.BahrainGrandPrix, data.SaudiArabiaGrandPrix, data.AustraliaGrandPrix});
        }
    }
}
