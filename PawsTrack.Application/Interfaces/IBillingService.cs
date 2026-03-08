using PawsTrack.Application.DTOs;

namespace PawsTrack.Application.Interfaces
{
    public interface IBillingService
    {
        Task<IReadOnlyList<BillableServiceDto>> SearchServicesAsync(string? clientName, DateTime? date, int? walkerId = null);
        Task<BillDto> CreateBillAsync(CreateBillRequest request);
        Task<IReadOnlyList<BillReportRowDto>> GetReportAsync(string? clientName, DateTime from, DateTime to, int? walkerId = null);
    }
}
