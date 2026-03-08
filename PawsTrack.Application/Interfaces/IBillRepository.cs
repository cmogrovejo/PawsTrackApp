using PawsTrack.Domain.Entities;

namespace PawsTrack.Application.Interfaces
{
    public interface IBillRepository
    {
        Task AddAsync(Bill bill);
    }
}
