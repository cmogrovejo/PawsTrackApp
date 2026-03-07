using PawsTrack.Domain.Enums;

namespace PawsTrack.Domain.Entities
{
    /// <summary>
    /// Represents a system user (dog walker / admin) who can log in.
    /// </summary>
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastLoginAt { get; private set; }
        public int FailedLoginAttempts { get; private set; }
        public DateTime? LockedUntil { get; private set; }

        private const int MaxFailedAttempts = 5;
        private static readonly TimeSpan LockoutDuration = TimeSpan.FromMinutes(15);

        private User()
        {
            Username = string.Empty;
            PasswordHash = string.Empty;
            FullName = string.Empty;
        }

        private User(string username, string passwordHash, string fullName, UserRole role)
        {
            Username = username;
            PasswordHash = passwordHash;
            FullName = fullName;
            Role = role;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            FailedLoginAttempts = 0;
        }

        /// <summary>
        /// Factory method — the only valid way to create a new User.
        /// </summary>
        public static User Create(string username, string passwordHash, string fullName, UserRole role = UserRole.Walker)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.", nameof(username));

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be empty.", nameof(fullName));

            return new User(username.Trim().ToLowerInvariant(), passwordHash, fullName.Trim(), role);
        }

        /// <summary>
        /// Returns true if this account is currently locked due to too many failed attempts.
        /// </summary>
        public bool IsLockedOut()
        {
            if (LockedUntil.HasValue && LockedUntil.Value > DateTime.UtcNow)
                return true;

            return false;
        }

        /// <summary>
        /// Records a successful login — resets lockout state and updates last login timestamp.
        /// </summary>
        public void RecordSuccessfulLogin()
        {
            FailedLoginAttempts = 0;
            LockedUntil = null;
            LastLoginAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Records a failed login attempt. Locks the account after MaxFailedAttempts.
        /// </summary>
        public void RecordFailedLoginAttempt()
        {
            FailedLoginAttempts++;

            if (FailedLoginAttempts >= MaxFailedAttempts)
            {
                LockedUntil = DateTime.UtcNow.Add(LockoutDuration);
            }
        }

        /// <summary>
        /// Updates the password hash — used by the admin reset flow.
        /// </summary>
        public void UpdatePasswordHash(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("New password hash cannot be empty.", nameof(newPasswordHash));

            PasswordHash = newPasswordHash;
            FailedLoginAttempts = 0;
            LockedUntil = null;
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;

        public void UpdateFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be empty.", nameof(fullName));

            FullName = fullName.Trim();
        }
    }
}
