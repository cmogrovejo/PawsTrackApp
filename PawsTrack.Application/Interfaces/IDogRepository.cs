using PawsTrack.Domain.Entities;

namespace PawsTrack.Application.Interfaces
{
    public interface IDogRepository
    {
        Task<Dog?> GetByIdAsync(int id);
        Task<IReadOnlyList<Dog>> GetByClientIdAsync(int clientId);
        Task AddAsync(Dog dog);
        Task UpdateAsync(Dog dog);
    }
}
