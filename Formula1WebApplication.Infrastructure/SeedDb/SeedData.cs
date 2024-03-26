using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Formula1WebApplication.Infrastructure.Data.SeedDb
{
    public class SeedData
    {
        public IdentityUser OrganizerUser { get; set; }
        public IdentityUser GuestUser { get; set; }
        public Organizer Organizer { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedOrganizer();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            OrganizerUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "organizer@mail.com",
                NormalizedUserName = "organizer@mail.com",
                Email = "organizer@mail.com",
                NormalizedEmail = "organizer@mail.com"
            };

            OrganizerUser.PasswordHash =
                 hasher.HashPassword(OrganizerUser, "organizer123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(OrganizerUser, "guest123");
        }

        private void SeedOrganizer()
        {
            Organizer = new Organizer()
            {
                Id = 1,
                PhoneNumber = "+359123123123",
                UserId = OrganizerUser.Id
            };
        }
    }
}
