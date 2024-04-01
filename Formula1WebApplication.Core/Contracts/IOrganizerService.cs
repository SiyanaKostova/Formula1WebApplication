namespace Formula1WebApplication.Core.Contracts
{
    public interface IOrganizerService
    {
        Task<bool> IsUserAlreadyOrganizerAsync(string userId);
        Task<bool> IsPhoneNumberAlreadyUsedAsync(string phoneNumber);
        Task<bool> BecomeOrganizerAsync(string userId, string phoneNumber);
        Task<int?> GetOrganizerIdAsync(string userId);
    }
}
