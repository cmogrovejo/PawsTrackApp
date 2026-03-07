using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;

namespace PawsTrack.Application.Services
{
    /// <summary>
    /// All business rules around login (lockout, validation, credential checking)
    /// live here — not in the UI and not in the repository.
    /// </summary>
    public sealed class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                return LoginResult.Failed("Username is required.");

            if (string.IsNullOrWhiteSpace(password))
                return LoginResult.Failed("Password is required.");

            var user = await _userRepository.GetByUsernameAsync(username.Trim().ToLowerInvariant());

            if (user is null)
                return LoginResult.Failed("Invalid username or password.");

            if (!user.IsActive)
                return LoginResult.Failed("This account has been deactivated. Please contact your administrator.");

            if (user.IsLockedOut())
            {
                return LoginResult.Failed(
                    $"Too many failed login attempts. Account locked until {user.LockedUntil!.Value.ToLocalTime():HH:mm:ss}.");
            }

            var passwordValid = _passwordHasher.Verify(password, user.PasswordHash);

            if (!passwordValid)
            {
                user.RecordFailedLoginAttempt();
                await _userRepository.UpdateAsync(user);

                // Provide lockout warning as the threshold approaches
                var remaining = 5 - user.FailedLoginAttempts;
                var message = remaining > 0
                    ? $"Invalid username or password. {remaining} attempt(s) remaining before lockout."
                    : $"Too many failed login attempts. Account locked for 15 minutes.";

                return LoginResult.Failed(message);
            }

            // --- Success path ---
            user.RecordSuccessfulLogin();
            await _userRepository.UpdateAsync(user);

            return LoginResult.Successful(new LoggedInUserDto
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                Role = user.Role
            });
        }

        public async Task<bool> CreateInitialAdminAsync(string username, string password, string fullName)
        {
            if (await _userRepository.AnyExistsAsync())
                throw new InvalidOperationException("Initial admin account can only be created when no users exist.");

            ValidatePasswordStrength(password);

            var hash = _passwordHasher.Hash(password);
            var admin = User.Create(username, hash, fullName, UserRole.Admin);

            await _userRepository.AddAsync(admin);
            return true;
        }

        public async Task<bool> ResetUserPasswordAsync(int userId, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("New password cannot be empty.", nameof(newPassword));

            ValidatePasswordStrength(newPassword);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                return false;

            var newHash = _passwordHasher.Hash(newPassword);
            user.UpdatePasswordHash(newHash);

            await _userRepository.UpdateAsync(user);
            return true;
        }

        private static void ValidatePasswordStrength(string password)
        {
            if (password.Length < 8)
                throw new ArgumentException("Password must be at least 8 characters long.");

            if (!password.Any(char.IsUpper))
                throw new ArgumentException("Password must contain at least one uppercase letter.");

            if (!password.Any(char.IsDigit))
                throw new ArgumentException("Password must contain at least one digit.");
        }
    }

}
