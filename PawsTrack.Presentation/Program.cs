using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Forms;

namespace PawsTrack.Presentation
{
    /// <summary>
    /// Application entry point.
    /// Responsibilities:
    ///   1. Build configuration (appsettings.json)
    ///   2. Register all services via DI
    ///   3. Apply EF Core migrations
    ///   4. Determine whether to show first-run setup or login form
    ///   5. Hand off to WinForms message loop
    /// </summary>
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
        
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            // --- Configuration ---
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("PawsTrack")
                ?? throw new InvalidOperationException("Connection string 'PawsTrack' not found in appsettings.json.");

            // --- DI Container ---
            var services = new ServiceCollection();
            services.AddPawsTrackServices(connectionString);

            // Register WinForms (transient so each form gets a fresh instance)
            services.AddTransient<LoginForm>();
            services.AddTransient<FirstRunSetupForm>();
            services.AddTransient<MainDashboardForm>();
            services.AddTransient<ClientIntakeForm>();

            ServiceProvider = services.BuildServiceProvider();

            // --- Database: apply migrations ---
            try
            {
                await ServiceProvider.InitializeDatabaseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to connect to the database.\n\n{ex.Message}\n\nPlease check your connection string in appsettings.json.",
                    "PawsTrack � Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // If no users exist at all, run first-time setup
            bool hasUsers;
            await using (var scope = ServiceProvider.CreateAsyncScope())
            {
                var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                hasUsers = await userRepo.AnyExistsAsync();
            }

            Form startingForm = hasUsers
                ? ServiceProvider.GetRequiredService<LoginForm>()
                : ServiceProvider.GetRequiredService<FirstRunSetupForm>();

            System.Windows.Forms.Application.Run(startingForm);
        }
    }
}