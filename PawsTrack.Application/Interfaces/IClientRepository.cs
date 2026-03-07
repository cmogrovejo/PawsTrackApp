using PawsTrack.Domain.Entities;

namespace PawsTrack.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<Client?> GetByIdAsync(int id);
        Task<IReadOnlyList<Client>> GetAllAsync();
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
    }
}
