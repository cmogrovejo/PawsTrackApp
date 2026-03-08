using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;

namespace PawsTrack.Application.Services
{
    public sealed class BillingService : IBillingService
    {
        private readonly IWalkServiceRepository _walkRepo;
        private readonly IClientRepository      _clientRepo;
        private readonly IDogRepository         _dogRepo;
        private readonly IBillRepository        _billRepo;

        public BillingService(
            IWalkServiceRepository walkRepo,
            IClientRepository      clientRepo,
            IDogRepository         dogRepo,
            IBillRepository        billRepo)
        {
            _walkRepo   = walkRepo;
            _clientRepo = clientRepo;
            _dogRepo    = dogRepo;
            _billRepo   = billRepo;
        }

        public async Task<IReadOnlyList<BillableServiceDto>> SearchServicesAsync(string? clientName, DateTime? date)
        {
            var services = await _walkRepo.SearchAsync(clientName, date, WalkStatus.Created);

            var result = new List<BillableServiceDto>(services.Count);
            foreach (var ws in services)
            {
                var client = await _clientRepo.GetByIdAsync(ws.ClientId);
                var dog    = await _dogRepo.GetByIdAsync(ws.DogId);

                var clientName2 = client?.FullName ?? $"Client #{ws.ClientId}";
                var dogName     = dog?.Name        ?? $"Dog #{ws.DogId}";
                var hours       = (ws.EndTime - ws.StartTime).TotalHours;

                result.Add(new BillableServiceDto(
                    ws.Id,
                    clientName2,
                    dogName,
                    ws.StartTime,
                    ws.EndTime,
                    ws.Status.ToString(),
                    hours));
            }

            return result;
        }

        public async Task<BillDto> CreateBillAsync(CreateBillRequest request)
        {
            var ws = await _walkRepo.GetByIdAsync(request.WalkServiceId)
                ?? throw new InvalidOperationException($"Walk service #{request.WalkServiceId} not found.");

            if (ws.Status != WalkStatus.Created)
                throw new InvalidOperationException("Only created walks can be billed.");

            var durationHours = (ws.EndTime - ws.StartTime).TotalHours;
            var bill = Bill.Create(request.WalkServiceId, request.RatePerHour, request.Discount, durationHours);

            await _billRepo.AddAsync(bill);

            return new BillDto(bill.Id, bill.WalkServiceId, bill.RatePerHour,
                               bill.Discount, bill.TotalAmount, bill.CreatedAt);
        }
    }
}
