using kokshengoj.Application.Users.Common;

namespace kokshengoj.Application.Common.Interfaces.Services
{
    public interface ICurrentUserService
    {
        Task<UserSafetyResult> GetCurrentUserAsync(string userState);
        Task<bool> IsAdminAsync(UserSafetyResult safetyUser);
    }
}
