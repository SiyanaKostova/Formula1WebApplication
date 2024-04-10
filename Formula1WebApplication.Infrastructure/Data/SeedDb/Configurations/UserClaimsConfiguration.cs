using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1WebApplication.Infrastructure.Data.SeedDb.Configurations
{
	internal class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
		{
			var data = new SeedData();

			builder.HasData(data.OrganizerUserClaim, data.GuestUserClaim, data.AdminUserClaim);
		}
	}
}
