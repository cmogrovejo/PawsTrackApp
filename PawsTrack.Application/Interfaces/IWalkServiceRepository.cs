using PawsTrack.Domain.Entities;

namespace PawsTrack.Application.Interfaces
{
    public interface IWalkServiceRepository
    {
        Task AddAsync(WalkService service);
        Task<WalkService?> GetByIdAsync(int id);
        Task<IReadOnlyList<WalkService>> GetByDateAsync(DateTime date);
        Task UpdateAsync(WalkService service);
        Task DeleteAsync(WalkService service);
    }
}
