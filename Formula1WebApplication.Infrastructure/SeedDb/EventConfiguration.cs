using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Data.SeedDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.SeedDb
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            var data = new SeedData();

            builder.HasData(new Event[] { data.MeetAndGreet, data.AutographSession, data.ExclusivePreview });
        }
    }
}
