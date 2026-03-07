using FluentAssertions;
using PawsTrack.Infrastructure.Security;

namespace PawsTrack.Tests.Infrastructure;

/// <summary>
/// Tests for the BCrypt password hasher.
/// These are lightweight integration tests — they exercise the real BCrypt library.
/// </summary>
public class BcryptPasswordHasherTests
{
    private readonly BcryptPasswordHasher _sut = new();

    [Fact]
    public void Hash_ProducesNonEmptyResult()
    {
        var hash = _sut.Hash("MyPassword1");
        hash.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Hash_TwiceForSamePassword_ProducesDifferentHashes()
    {
        // BCrypt uses a random salt — two identical passwords must hash differently
        var hash1 = _sut.Hash("MyPassword1");
        var hash2 = _sut.Hash("MyPassword1");
        hash1.Should().NotBe(hash2);
    }

    [Fact]
    public void Verify_CorrectPassword_ReturnsTrue()
    {
        var hash = _sut.Hash("MyPassword1");
        _sut.Verify("MyPassword1", hash).Should().BeTrue();
    }

    [Fact]
    public void Verify_WrongPassword_ReturnsFalse()
    {
        var hash = _sut.Hash("MyPassword1");
        _sut.Verify("WrongPassword", hash).Should().BeFalse();
    }

    [Fact]
    public void Verify_InvalidHashFormat_ReturnsFalse()
    {
        // Should not throw — must gracefully return false for malformed hashes
        _sut.Verify("password", "not-a-valid-bcrypt-hash").Should().BeFalse();
    }

    [Fact]
    public void Hash_EmptyPassword_ThrowsArgumentException()
    {
        var act = () => _sut.Hash("  ");
        act.Should().Throw<ArgumentException>();
    }
}
