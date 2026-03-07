using Microsoft.EntityFrameworkCore;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Infrastructure.Persistence
{
    /// <summary>
    /// The EF Core DbContext for PawsTrack.
    /// </summary>
    public sealed class PawsTrackDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public PawsTrackDbContext(DbContextOptions<PawsTrackDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureUsers(modelBuilder);
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
