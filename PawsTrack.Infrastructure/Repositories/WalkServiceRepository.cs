using Microsoft.EntityFrameworkCore;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;
using PawsTrack.Infrastructure.Persistence;

namespace PawsTrack.Infrastructure.Repositories
{
    public sealed class WalkServiceRepository : IWalkServiceRepository
    {
        private readonly PawsTrackDbContext _context;

        public WalkServiceRepository(PawsTrackDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(WalkService service)
        {
            await _context.WalkServices.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task<WalkService?> GetByIdAsync(int id)
            => await _context.WalkServices.FindAsync(id);

        public async Task<IReadOnlyList<WalkService>> GetByDateAsync(DateTime date, int? walkerId = null)
        {
            var query = _context.WalkServices
                .AsNoTracking()
                .Where(s => s.StartTime.Date == date.Date);

            if (walkerId.HasValue)
                query = query.Where(s => s.WalkerId == walkerId.Value);

            return await query.OrderBy(s => s.StartTime).ToListAsync();
        }

        public async Task<IReadOnlyList<WalkService>> SearchAsync(string? clientName, DateTime? date, WalkStatus? status, int? walkerId = null)
        {
            var query = _context.WalkServices.AsNoTracking().AsQueryable();

            if (walkerId.HasValue)
                query = query.Where(ws => ws.WalkerId == walkerId.Value);

            if (status.HasValue)
                query = query.Where(ws => ws.Status == status.Value);

            if (date.HasValue)
                query = query.Where(ws => ws.StartTime.Date == date.Value.Date);

            if (!string.IsNullOrWhiteSpace(clientName))
            {
                var lower = clientName.Trim().ToLower();
                var ids = await _context.Clients
                    .Where(c => c.FullName.ToLower().Contains(lower))
                    .Select(c => c.Id)
                    .ToListAsync();
                query = query.Where(ws => ids.Contains(ws.ClientId));
            }

            return await query.OrderBy(ws => ws.StartTime).ToListAsync();
        }

        public async Task UpdateAsync(WalkService service)
        {
            _context.WalkServices.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(WalkService service)
        {
            _context.WalkServices.Remove(service);
            await _context.SaveChangesAsync();
        }
    }
}
