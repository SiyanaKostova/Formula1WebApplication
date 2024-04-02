using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1WebApplication.Core.Services
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IRepository repository;

        public OrganizerService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> IsUserAlreadyOrganizerAsync(string userId)
        {
            return await repository.AllReadOnly<Organizer>()
                .AnyAsync(o => o.UserId == userId);
        }

        public async Task<bool> IsPhoneNumberAlreadyUsedAsync(string phoneNumber)
        {
            return await repository.All<Organizer>()
                .AnyAsync(o => o.PhoneNumber == phoneNumber);
        }

        public async Task<bool> BecomeOrganizerAsync(string userId, string phoneNumber)
        {
            if (await IsUserAlreadyOrganizerAsync(userId) || 
                await IsPhoneNumberAlreadyUsedAsync(phoneNumber))
            {
                return false;
            }

            var organizer = new Organizer
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await repository.AddAsync(organizer);
            await repository.SaveChangesAsync();

            return true;
        }

        public async Task<int?> GetOrganizerIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Organizer>()
                .FirstOrDefaultAsync(o => o.UserId == userId))?.Id;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Organizer>()
                .AnyAsync(o => o.UserId == userId);
        }
    }
}
