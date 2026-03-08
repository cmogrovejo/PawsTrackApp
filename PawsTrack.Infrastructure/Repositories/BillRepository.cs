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
    }
}
