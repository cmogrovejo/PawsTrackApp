using Microsoft.EntityFrameworkCore;
using PawsTrack.Application.Interfaces;
using PawsTrack.Application.Services;
using PawsTrack.Infrastructure.Persistence;
using PawsTrack.Infrastructure.Repositories;
using PawsTrack.Infrastructure.Security;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Registers all Infrastructure and Application services into the DI container.
    /// Called once from Program.cs
    /// </summary>
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPawsTrackServices(
            this IServiceCollection services,
            string connectionString)
        {
            // --- Persistence ---
            // Scoped lifetime matches EF Core's recommended pattern:
            // one DbContext instance per unit of work (form interaction).
            services.AddDbContext<PawsTrackDbContext>(options =>
                options.UseSqlServer(connectionString));

            // --- Repositories ---
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<IWalkServiceRepository, WalkServiceRepository>();

            // --- Security ---
            // Singleton is safe: BcryptPasswordHasher holds no mutable state.
            services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>();

            // --- Application Services ---
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IIntakeService, IntakeService>();
            services.AddScoped<IWalkScheduleService, WalkScheduleService>();

            return services;
        }
    }
}
