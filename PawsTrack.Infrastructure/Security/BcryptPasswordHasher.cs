using PawsTrack.Application.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace PawsTrack.Infrastructure.Security
{
    /// <summary>
    /// BCrypt is appropriate here because it is:
    ///   - Adaptive: the work factor can be increased as hardware improves
    ///   - Salted: each hash is unique even for identical passwords
    ///   - Resistant to GPU-based attacks
    ///
    /// Work factor of 12 is a pragmatic balance between security and
    /// login latency on typical desktop hardware (~250ms).
    /// </summary>
    public sealed class BcryptPasswordHasher : IPasswordHasher
    {
        private const int WorkFactor = 12;

        public string Hash(string plainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(plainTextPassword))
                throw new ArgumentException("Password cannot be empty.", nameof(plainTextPassword));

            return BC.HashPassword(plainTextPassword, WorkFactor);
        }

        public bool Verify(string plainTextPassword, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(plainTextPassword) || string.IsNullOrWhiteSpace(storedHash))
                return false;

            try
            {
                return BC.Verify(plainTextPassword, storedHash);
            }
            catch
            {
                // Treat that as a failed verification rather than a crash.
                return false;
            }
        }
    }
}
