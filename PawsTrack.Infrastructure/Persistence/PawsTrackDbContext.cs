using Microsoft.EntityFrameworkCore;
using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;

namespace PawsTrack.Infrastructure.Persistence
{
    /// <summary>
    /// The EF Core DbContext for PawsTrack.
    /// </summary>
    public sealed class PawsTrackDbContext : DbContext
    {
        public DbSet<User>        Users        => Set<User>();
        public DbSet<Client>      Clients      => Set<Client>();
        public DbSet<Dog>         Dogs         => Set<Dog>();
        public DbSet<WalkService> WalkServices => Set<WalkService>();
        public DbSet<Bill>        Bills        { get; set; } = null!;

        public PawsTrackDbContext(DbContextOptions<PawsTrackDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureUsers(modelBuilder);
            ConfigureClients(modelBuilder);
            ConfigureDogs(modelBuilder);
            ConfigureWalkServices(modelBuilder);
            ConfigureBills(modelBuilder);
        }

        private static void ConfigureClients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();

                entity.Property(c => c.FullName).IsRequired().HasMaxLength(200);
                entity.Property(c => c.Phone).IsRequired().HasMaxLength(20);
                entity.Property(c => c.Address).IsRequired().HasMaxLength(300);
                entity.Property(c => c.CreatedAt).IsRequired();

                entity.Navigation(c => c.Dogs).UsePropertyAccessMode(PropertyAccessMode.Field);

                entity.HasMany(c => c.Dogs)
                      .WithOne(d => d.Client)
                      .HasForeignKey(d => d.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>(entity =>
            {
                entity.ToTable("Dogs");
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Id).ValueGeneratedOnAdd();

                entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
                entity.Property(d => d.AgeYears).IsRequired();
                entity.Property(d => d.Breed).IsRequired().HasMaxLength(100);
                entity.Property(d => d.MedicalNotes).IsRequired(false).HasMaxLength(2000);
                entity.Property(d => d.ClientId).IsRequired();
                entity.Property(d => d.CreatedAt).IsRequired();
            });
        }

        private static void ConfigureWalkServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WalkService>(entity =>
            {
                entity.ToTable("WalkServices");
                entity.HasKey(w => w.Id);
                entity.Property(w => w.Id).ValueGeneratedOnAdd();

                entity.Property(w => w.WalkerId).IsRequired();
                entity.Property(w => w.ClientId).IsRequired();
                entity.Property(w => w.DogId).IsRequired();
                entity.Property(w => w.StartTime).IsRequired();
                entity.Property(w => w.EndTime).IsRequired();
                entity.Property(w => w.Status)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20);
                entity.Property(w => w.CreatedAt).IsRequired();

                entity.HasIndex(w => w.StartTime).HasDatabaseName("IX_WalkServices_StartTime");
                entity.HasIndex(w => w.WalkerId).HasDatabaseName("IX_WalkServices_WalkerId");
            });
        }

        private static void ConfigureBills(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bills");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id).ValueGeneratedOnAdd();

                entity.Property(b => b.WalkServiceId).IsRequired();
                entity.Property(b => b.RatePerHour).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(b => b.Discount).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(b => b.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(b => b.CreatedAt).IsRequired();

                entity.HasIndex(b => b.WalkServiceId).HasDatabaseName("IX_Bills_WalkServiceId");
            });
        }

        private static void ConfigureUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(u => u.Username)
                      .IsRequired()
                      .HasMaxLength(100);

                // Unique index: two users cannot share the same username
                entity.HasIndex(u => u.Username)
                      .IsUnique()
                      .HasDatabaseName("IX_Users_Username");

                entity.Property(u => u.PasswordHash)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.Property(u => u.FullName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(u => u.Role)
                      .IsRequired()
                      .HasConversion<int>();

                entity.Property(u => u.IsActive)
                      .IsRequired()
                      .HasDefaultValue(true);

                entity.Property(u => u.CreatedAt)
                      .IsRequired();

                entity.Property(u => u.LastLoginAt)
                      .IsRequired(false);

                entity.Property(u => u.FailedLoginAttempts)
                      .IsRequired()
                      .HasDefaultValue(0);

                entity.Property(u => u.LockedUntil)
                      .IsRequired(false);
            });
        }
    }
}
