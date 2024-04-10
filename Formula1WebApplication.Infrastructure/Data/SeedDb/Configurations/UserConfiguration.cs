using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.Data.SeedDb.Configurations
{
	internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new ApplicationUser[] { data.OrganizerUser, data.GuestUser });
        }
    }
}