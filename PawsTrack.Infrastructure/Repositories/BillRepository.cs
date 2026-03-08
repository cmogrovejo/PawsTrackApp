using Microsoft.EntityFrameworkCore;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;
using PawsTrack.Infrastructure.Persistence;

namespace PawsTrack.Infrastructure.Repositories
{
    public sealed class BillRepository : IBillRepository
    {
        private readonly PawsTrackDbContext _context;

        public BillRepository(PawsTrackDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<BillReportRowDto>> GetReportAsync(
            string? clientName, DateTime from, DateTime to, int? walkerId = null)
        {
            // NOTE: Bill.CreatedAt is stored as UTC (DateTime.UtcNow).
            var lower  = clientName?.Trim().ToLower();
            var toExcl = to.Date.AddDays(1); // include all of the `to` day

            var query = _context.Bills
                .AsNoTracking()
                .Join(_context.WalkServices, b => b.WalkServiceId, ws => ws.Id,
                      (b, ws) => new { b, ws })
                .Join(_context.Clients, x => x.ws.ClientId, c => c.Id,
                      (x, c) => new { x.b, x.ws, c })
                .Join(_context.Dogs, x => x.ws.DogId, d => d.Id,
                      (x, d) => new { x.b, x.ws, x.c, d })
                .Where(x => x.b.CreatedAt >= from.Date && x.b.CreatedAt < toExcl);

            if (walkerId.HasValue)
                query = query.Where(x => x.ws.WalkerId == walkerId.Value);

            if (!string.IsNullOrWhiteSpace(lower))
                query = query.Where(x => x.c.FullName.ToLower().Contains(lower));

            // Project to anonymous type first; compute TotalHours in-memory to avoid
            // LINQ-to-SQL translation issues with TimeSpan arithmetic.
            var raw = await query
                .OrderBy(x => x.b.CreatedAt)
                .Select(x => new {
                    x.c.FullName, x.d.Name,
                    x.ws.StartTime, x.ws.EndTime,
                    x.b.RatePerHour, x.b.Discount, x.b.TotalAmount, x.b.CreatedAt
                })
                .ToListAsync();

            return raw.Select(x => new BillReportRowDto(
                x.FullName, x.Name,
                x.StartTime.Date, x.StartTime, x.EndTime,
                (x.EndTime - x.StartTime).TotalHours,
                x.RatePerHour, x.Discount, x.TotalAmount,
                x.CreatedAt))
                .ToList();
        }
    }
}
