using PawsTrack.Application.DTOs;

namespace PawsTrack.Application.Interfaces
{
    public interface IWalkScheduleService
    {
        Task<WalkServiceCreatedDto> CreateAsync(CreateWalkServiceRequest request);
        Task<IReadOnlyList<DogSummaryDto>> GetDogsByClientAsync(int clientId);
        Task<IReadOnlyList<WalkServiceCreatedDto>> GetByDateAsync(DateTime date, int? walkerId = null);
        Task UpdateAsync(UpdateWalkServiceRequest request);
        Task DeleteAsync(int id);
    }
}
