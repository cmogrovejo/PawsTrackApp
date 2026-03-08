using Microsoft.EntityFrameworkCore;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;
using PawsTrack.Infrastructure.Persistence;

namespace PawsTrack.Infrastructure.Repositories
{
    public sealed class ClientRepository : IClientRepository
    {
        private readonly PawsTrackDbContext _context;

        public ClientRepository(PawsTrackDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IReadOnlyList<Client>> GetAllAsync()
        {
            return await _context.Clients
                .AsNoTracking()
                .OrderBy(c => c.FullName)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Client>> SearchAsync(string searchTerm)
        {
            var term = searchTerm?.Trim().ToLower() ?? string.Empty;
            var query = _context.Clients.AsNoTracking();

            if (!string.IsNullOrEmpty(term))
                query = query.Where(c => c.FullName.ToLower().Contains(term) || c.Phone.Contains(term));

            return await query.OrderBy(c => c.FullName).ToListAsync();
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
