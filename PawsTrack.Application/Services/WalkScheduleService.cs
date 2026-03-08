using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;

namespace PawsTrack.Application.Services
{
    public sealed class WalkScheduleService : IWalkScheduleService
    {
        private readonly IWalkServiceRepository _walkRepo;
        private readonly IClientRepository      _clientRepo;
        private readonly IDogRepository         _dogRepo;

        public WalkScheduleService(
            IWalkServiceRepository walkRepo,
            IClientRepository      clientRepo,
            IDogRepository         dogRepo)
        {
            _walkRepo   = walkRepo   ?? throw new ArgumentNullException(nameof(walkRepo));
            _clientRepo = clientRepo ?? throw new ArgumentNullException(nameof(clientRepo));
            _dogRepo    = dogRepo    ?? throw new ArgumentNullException(nameof(dogRepo));
        }

        public async Task<WalkServiceCreatedDto> CreateAsync(CreateWalkServiceRequest request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var client = await _clientRepo.GetByIdAsync(request.ClientId)
                ?? throw new ArgumentException($"Client with ID {request.ClientId} not found.");

            var dog = await _dogRepo.GetByIdAsync(request.DogId)
                ?? throw new ArgumentException($"Dog with ID {request.DogId} not found.");

            if (dog.ClientId != client.Id)
                throw new ArgumentException("The selected dog does not belong to the selected client.");

            var service = WalkService.Create(request.WalkerId, request.ClientId, request.DogId, request.StartTime, request.EndTime);
            await _walkRepo.AddAsync(service);

            return new WalkServiceCreatedDto
            {
                Id         = service.Id,
                ClientName = client.FullName,
                DogName    = dog.Name,
                StartTime  = service.StartTime,
                EndTime    = service.EndTime,
                Status     = service.Status.ToString()
            };
        }

        public async Task<IReadOnlyList<DogSummaryDto>> GetDogsByClientAsync(int clientId)
        {
            var dogs = await _dogRepo.GetByClientIdAsync(clientId);
            return dogs.Select(d => new DogSummaryDto { Id = d.Id, Name = d.Name }).ToList();
        }

        public async Task<IReadOnlyList<WalkServiceCreatedDto>> GetByDateAsync(DateTime date, int? walkerId = null)
        {
            var walks = await _walkRepo.GetByDateAsync(date, walkerId);

            var result = new List<WalkServiceCreatedDto>(walks.Count);
            foreach (var w in walks)
            {
                var client = await _clientRepo.GetByIdAsync(w.ClientId);
                var dog    = await _dogRepo.GetByIdAsync(w.DogId);
                result.Add(new WalkServiceCreatedDto
                {
                    Id         = w.Id,
                    ClientName = client?.FullName ?? $"Client #{w.ClientId}",
                    DogName    = dog?.Name        ?? $"Dog #{w.DogId}",
                    StartTime  = w.StartTime,
                    EndTime    = w.EndTime,
                    Status     = w.Status.ToString()
                });
            }
            return result;
        }

        public async Task UpdateAsync(UpdateWalkServiceRequest request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var service = await _walkRepo.GetByIdAsync(request.Id)
                ?? throw new ArgumentException($"Walk service {request.Id} not found.");

            service.Reschedule(request.StartTime, request.EndTime);
            await _walkRepo.UpdateAsync(service);
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _walkRepo.GetByIdAsync(id)
                ?? throw new ArgumentException($"Walk service {id} not found.");

            if (service.Status != WalkStatus.Created)
                throw new InvalidOperationException("Only services in 'Created' status can be deleted.");

            await _walkRepo.DeleteAsync(service);
        }
    }
}
