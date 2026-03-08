using Microsoft.EntityFrameworkCore;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;
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

        public async Task<IReadOnlyList<WalkService>> GetByDateAsync(DateTime date)
        {
            return await _context.WalkServices
                .AsNoTracking()
                .Where(s => s.StartTime.Date == date.Date)
                .OrderBy(s => s.StartTime)
                .ToListAsync();
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
