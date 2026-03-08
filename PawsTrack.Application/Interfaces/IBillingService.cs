using PawsTrack.Application.DTOs;

namespace PawsTrack.Application.Interfaces
{
    public interface IBillingService
    {
        Task<IReadOnlyList<BillableServiceDto>> SearchServicesAsync(string? clientName, DateTime? date);
        Task<BillDto> CreateBillAsync(CreateBillRequest request);
    }
}
