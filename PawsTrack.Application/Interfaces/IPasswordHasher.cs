namespace PawsTrack.Application.Interfaces
{
    /// <summary>
    /// Abstraction for password hashing and verification.
    /// </summary>
    public interface IPasswordHasher
    {
        string Hash(string plainTextPassword);
        bool Verify(string plainTextPassword, string storedHash);
    }
}
