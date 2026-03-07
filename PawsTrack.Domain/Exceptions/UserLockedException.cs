
namespace PawsTrack.Domain.Exceptions
{
    /// <summary>
    /// Raised when a user attempts to log in while their account is locked out.
    /// </summary>
    public class UserLockedException : DomainException
    {
        public DateTime LockedUntil { get; }

        public UserLockedException(DateTime lockedUntil)
            : base($"Account is locked until {lockedUntil.ToLocalTime():HH:mm:ss}. Please try again later.")
        {
            LockedUntil = lockedUntil;
        }
    }
}
