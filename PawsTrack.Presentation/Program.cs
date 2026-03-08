using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Forms;
using PawsTrack.Presentation.UserControls;
using QuestPDF.Infrastructure;

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

        // Must be void (not async Task) so [STAThread] remains in effect for the
        // entire lifetime of the process. Using async Task Main causes the message
        // loop — and all button-click handlers — to run on an MTA thread pool
        // thread, which breaks OLE calls such as ComboBox AutoComplete.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            QuestPDF.Settings.License = LicenseType.Community;

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
            services.AddTransient<MainDashboardDogWalkerForm>();
            services.AddTransient<MainDashboardAdminForm>();
            services.AddTransient<ClientIntakeUC>();
            services.AddTransient<RegisterDogWalkerForm>();
            services.AddTransient<NewServiceUC>();
            services.AddTransient<CreateBillForm>();

            ServiceProvider = services.BuildServiceProvider();

            // --- Database: apply migrations ---
            // Task.Run offloads the async work to the thread pool so the STA
            // thread is never abandoned and OLE/WinForms controls stay on STA.
            try
            {
                Task.Run(() => ServiceProvider.InitializeDatabaseAsync()).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to connect to the database.\n\n{ex.Message}\n\nPlease check your connection string in appsettings.json.",
                    "PawsTrack \u26a0 Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // If no users exist at all, run first-time setup
            bool hasUsers = Task.Run(async () =>
            {
                await using var scope = ServiceProvider.CreateAsyncScope();
                var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                return await userRepo.AnyExistsAsync();
            }).GetAwaiter().GetResult();

            Form startingForm = hasUsers
                ? ServiceProvider.GetRequiredService<LoginForm>()
                : ServiceProvider.GetRequiredService<FirstRunSetupForm>();

            System.Windows.Forms.Application.Run(startingForm);
        }
    }
}
