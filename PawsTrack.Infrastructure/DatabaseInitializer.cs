using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Infrastructure.Persistence;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Applies any pending EF Core migrations at application startup.
    /// This ensures the database schema is always in sync with the codebase
    /// without requiring a manual migration step from the user.
    /// </summary>
    public static class DatabaseInitializer
    {
        public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
        {
            // Use a scope so the scoped DbContext is properly disposed after migration.
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<PawsTrackDbContext>();
            await db.Database.MigrateAsync();
        }
    }
}
