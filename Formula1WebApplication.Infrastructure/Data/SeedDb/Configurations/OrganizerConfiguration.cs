using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.Data.SeedDb.Configurations
{
    internal class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            var data = new SeedData();

            builder.HasData(new Organizer[] { data.Organizer, data.AdminOrganizer });
        }
    }
}
