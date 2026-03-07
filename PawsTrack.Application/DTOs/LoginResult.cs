using PawsTrack.Domain.Enums;

namespace PawsTrack.Application.DTOs
{
    /// <summary>
    /// The result returned to the Presentation layer after a login attempt.
    /// </summary>
    public class LoginResult
    {
        public bool Success { get; private init; }
        public string? ErrorMessage { get; private init; }
        public LoggedInUserDto? User { get; private init; }

        private LoginResult() { }

        public static LoginResult Successful(LoggedInUserDto user) =>
            new() { Success = true, User = user };

        public static LoginResult Failed(string errorMessage) =>
            new() { Success = false, ErrorMessage = errorMessage };
    }

    /// <summary>
    /// A snapshot of the currently logged-in user.
    /// Passed to other parts of the application after a successful login.
    /// </summary>
    public class LoggedInUserDto
    {
        public int Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public UserRole Role { get; init; }
    }
}
