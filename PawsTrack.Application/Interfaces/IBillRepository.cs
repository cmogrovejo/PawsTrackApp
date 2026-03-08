using PawsTrack.Application.DTOs;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Application.Interfaces
{
    public interface IBillRepository
    {
        Task AddAsync(Bill bill);
        Task<IReadOnlyList<BillReportRowDto>> GetReportAsync(string? clientName, DateTime from, DateTime to, int? walkerId = null);
    }
}
