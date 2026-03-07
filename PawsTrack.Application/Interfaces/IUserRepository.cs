using PawsTrack.Domain.Entities;

namespace PawsTrack.Application.Interfaces;
/// <summary>
/// Contract for user persistence operations.
/// The Application layer depends on this abstraction — not on EF Core or SQL Server directly.
/// </summary>
public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByIdAsync(int id);
    Task<IReadOnlyList<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<bool> AnyExistsAsync();
}
