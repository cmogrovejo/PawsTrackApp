using PawsTrack.Application.DTOs;

namespace PawsTrack.Application.Interfaces
{
    public interface IIntakeService
    {
        Task<ClientCreatedDto> CreateClientWithDogAsync(CreateClientRequest clientReq, CreateDogRequest dogReq);
    }
}
