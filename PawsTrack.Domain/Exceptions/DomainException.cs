
namespace PawsTrack.Domain.Exceptions
{
    /// <summary>
    /// Keeps business rule violations separate from infrastructure or UI exceptions.
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
        public DomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
