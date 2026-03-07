using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PawsTrack.Infrastructure.Persistence
{
    /// <summary>
    /// Used exclusively by EF Core design-time tools for dotnet ef migrations.
    /// Not referenced at runtime — the DI container handles DbContext creation there.
    /// </summary>
    public sealed class PawsTrackDbContextFactory : IDesignTimeDbContextFactory<PawsTrackDbContext>
    {
        public PawsTrackDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "PawsTrack.Presentation"))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("PawsTrack")
                ?? throw new InvalidOperationException("Connection string 'PawsTrack' not found.");

            var options = new DbContextOptionsBuilder<PawsTrackDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new PawsTrackDbContext(options);
        }
    }
}
