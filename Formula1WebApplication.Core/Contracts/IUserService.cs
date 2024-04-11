using Formula1WebApplication.Core.Models.User;

namespace Formula1WebApplication.Core.Contracts
{
    public interface IUserService
    {
        Task<string> GetUserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> AllUsersAsync();
    }
}
