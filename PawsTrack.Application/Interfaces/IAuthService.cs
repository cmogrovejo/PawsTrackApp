using PawsTrack.Application.DTOs;

namespace PawsTrack.Application.Interfaces
{
    /// <summary>
    /// Defines the authentication contract used by the Presentation layer.
    /// The UI only knows about this interface — it is injected and never instantiated directly.
    /// </summary>
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync(string username, string password);
        Task<bool> CreateInitialAdminAsync(string username, string password, string fullName);
        Task<bool> CreateWalkerAsync(string username, string password, string fullName);
        Task<bool> ResetUserPasswordAsync(int userId, string newPassword);
        Task<IReadOnlyList<UserSummaryDto>> GetWalkersAsync(string? search = null);
    }
}
