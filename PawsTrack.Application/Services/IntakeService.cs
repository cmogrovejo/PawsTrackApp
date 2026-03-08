using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Application.Services
{
    public sealed class IntakeService : IIntakeService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IDogRepository _dogRepository;

        public IntakeService(IClientRepository clientRepository, IDogRepository dogRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _dogRepository    = dogRepository    ?? throw new ArgumentNullException(nameof(dogRepository));
        }

        public async Task<ClientCreatedDto> CreateClientWithDogAsync(CreateClientRequest clientReq, CreateDogRequest dogReq)
        {
            if (clientReq is null) throw new ArgumentNullException(nameof(clientReq));
            if (dogReq    is null) throw new ArgumentNullException(nameof(dogReq));

            var client = Client.Create(clientReq.FullName, clientReq.Phone, clientReq.Address);
            await _clientRepository.AddAsync(client);

            var dog = Dog.Create(dogReq.Name, dogReq.AgeYears, dogReq.Breed, dogReq.MedicalNotes, client.Id);
            await _dogRepository.AddAsync(dog);

            return new ClientCreatedDto
            {
                ClientId       = client.Id,
                ClientFullName = client.FullName,
                DogId          = dog.Id,
                DogName        = dog.Name
            };
        }

        public async Task<IReadOnlyList<ClientSummaryDto>> SearchClientsAsync(string searchTerm)
        {
            var clients = await _clientRepository.SearchAsync(searchTerm ?? string.Empty);
            return clients.Select(c => new ClientSummaryDto
            {
                Id       = c.Id,
                FullName = c.FullName,
                Phone    = c.Phone,
                Address  = c.Address
            }).ToList();
        }

        public async Task<ClientCreatedDto> AddDogToExistingClientAsync(int clientId, CreateDogRequest dogReq)
        {
            if (dogReq is null) throw new ArgumentNullException(nameof(dogReq));

            var client = await _clientRepository.GetByIdAsync(clientId)
                ?? throw new ArgumentException($"Client with ID {clientId} not found.");

            var dog = Dog.Create(dogReq.Name, dogReq.AgeYears, dogReq.Breed, dogReq.MedicalNotes, client.Id);
            await _dogRepository.AddAsync(dog);

            return new ClientCreatedDto
            {
                ClientId       = client.Id,
                ClientFullName = client.FullName,
                DogId          = dog.Id,
                DogName        = dog.Name
            };
        }
    }
}
