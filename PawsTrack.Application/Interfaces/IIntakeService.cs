using PawsTrack.Application.DTOs;

namespace PawsTrack.Application.Interfaces
{
    public interface IIntakeService
    {
        Task<ClientCreatedDto> CreateClientWithDogAsync(CreateClientRequest clientReq, CreateDogRequest dogReq);
        Task<IReadOnlyList<ClientSummaryDto>> SearchClientsAsync(string searchTerm);
        Task<ClientCreatedDto> AddDogToExistingClientAsync(int clientId, CreateDogRequest dogReq);
    }
}
