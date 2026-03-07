using Microsoft.EntityFrameworkCore;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;
using PawsTrack.Infrastructure.Persistence;

namespace PawsTrack.Infrastructure.Repositories
{
    public sealed class DogRepository : IDogRepository
    {
        private readonly PawsTrackDbContext _context;

        public DogRepository(PawsTrackDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Dog?> GetByIdAsync(int id)
        {
            return await _context.Dogs
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IReadOnlyList<Dog>> GetByClientIdAsync(int clientId)
        {
            return await _context.Dogs
                .AsNoTracking()
                .Where(d => d.ClientId == clientId)
                .OrderBy(d => d.Name)
                .ToListAsync();
        }

        public async Task AddAsync(Dog dog)
        {
            await _context.Dogs.AddAsync(dog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dog dog)
        {
            _context.Dogs.Update(dog);
            await _context.SaveChangesAsync();
        }
    }
}
