using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.Data.SeedDb.Configurations
{
    internal class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder
            .HasOne(r => r.Organizer)
            .WithMany(o => o.Races)
            .HasForeignKey(r => r.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Race[] { data.BahrainGrandPrix, data.SaudiArabiaGrandPrix, data.AustraliaGrandPrix });
        }
    }
}
