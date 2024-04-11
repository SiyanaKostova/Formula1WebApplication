using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.User;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1WebApplication.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<UserServiceModel>> AllUsersAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                            .Include(u => u.Organizer)
                            .Select(u => new UserServiceModel()
                            {
                                Email = u.Email,
                                FullName = $"{u.FirstName} {u.LastName}",
                                PhoneNumber = u.Organizer != null ? u.Organizer.PhoneNumber : null,
                                IsOrganizer = u.Organizer != null
                            })
                            .ToListAsync();
        }

        public async Task<string> GetUserFullNameAsync(string userId)
        {
            string fullName = string.Empty;

            var user = await repository
                .GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                fullName = $"{user.FirstName} {user.LastName}";
            }

            return fullName;
        }
    }
}
