using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;

namespace PawsTrack.Application.Interfaces
{
    public interface IWalkServiceRepository
    {
        Task AddAsync(WalkService service);
        Task<WalkService?> GetByIdAsync(int id);
        Task<IReadOnlyList<WalkService>> GetByDateAsync(DateTime date, int? walkerId = null);
        Task<IReadOnlyList<WalkService>> SearchAsync(string? clientName, DateTime? date, WalkStatus? status, int? walkerId = null);
        Task UpdateAsync(WalkService service);
        Task DeleteAsync(WalkService service);
    }
}
