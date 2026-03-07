using FluentAssertions;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Tests.Domain;

/// <summary>
/// Tests for the User entity's business rules.
/// Pure domain tests — no DB, no network, no DI.
/// </summary>
public class UserEntityTests
{
    // ── Factory method validation ──────────────────────────────────────────

    [Fact]
    public void Create_WithValidData_CreatesActiveUser()
    {
        var user = User.Create("john", "hash123", "John Doe");

        user.Username.Should().Be("john");
        user.FullName.Should().Be("John Doe");
        user.IsActive.Should().BeTrue();
        user.FailedLoginAttempts.Should().Be(0);
        user.LockedUntil.Should().BeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithEmptyUsername_ThrowsArgumentException(string? username)
    {
        var act = () => User.Create(username!, "hash", "Name");
        act.Should().Throw<ArgumentException>().WithMessage("*Username*");
    }

    [Fact]
    public void Create_NormalizesUsernameLowercase()
    {
        var user = User.Create("WALKER_One", "hash", "Walker One");
        user.Username.Should().Be("walker_one");
    }

    // ── Lockout rules ──────────────────────────────────────────────────────

    [Fact]
    public void IsLockedOut_InitialState_ReturnsFalse()
    {
        var user = User.Create("u", "h", "Name");
        user.IsLockedOut().Should().BeFalse();
    }

    [Fact]
    public void RecordFailedLoginAttempt_After5Failures_LocksAccount()
    {
        var user = User.Create("u", "h", "Name");

        for (int i = 0; i < 5; i++)
            user.RecordFailedLoginAttempt();

        user.IsLockedOut().Should().BeTrue();
        user.LockedUntil.Should().NotBeNull();
        user.LockedUntil!.Value.Should().BeAfter(DateTime.UtcNow);
    }

    [Fact]
    public void RecordFailedLoginAttempt_Below5Failures_DoesNotLockAccount()
    {
        var user = User.Create("u", "h", "Name");

        for (int i = 0; i < 4; i++)
            user.RecordFailedLoginAttempt();

        user.IsLockedOut().Should().BeFalse();
    }

    [Fact]
    public void RecordSuccessfulLogin_ResetsFailedAttemptsAndLockout()
    {
        var user = User.Create("u", "h", "Name");
        for (int i = 0; i < 5; i++) user.RecordFailedLoginAttempt();
        user.IsLockedOut().Should().BeTrue();

        user.RecordSuccessfulLogin();

        user.FailedLoginAttempts.Should().Be(0);
        user.IsLockedOut().Should().BeFalse();
        user.LastLoginAt.Should().NotBeNull();
    }

    // ── Password reset ─────────────────────────────────────────────────────

    [Fact]
    public void UpdatePasswordHash_WithValidHash_UpdatesAndClearsLockout()
    {
        var user = User.Create("u", "oldhash", "Name");
        for (int i = 0; i < 5; i++) user.RecordFailedLoginAttempt();

        user.UpdatePasswordHash("newhash");

        user.PasswordHash.Should().Be("newhash");
        user.FailedLoginAttempts.Should().Be(0);
        user.IsLockedOut().Should().BeFalse();
    }

    [Fact]
    public void UpdatePasswordHash_WithEmptyHash_ThrowsArgumentException()
    {
        var user = User.Create("u", "h", "Name");
        var act = () => user.UpdatePasswordHash("  ");
        act.Should().Throw<ArgumentException>();
    }

    // ── Activation / deactivation ──────────────────────────────────────────

    [Fact]
    public void Deactivate_SetsIsActiveToFalse()
    {
        var user = User.Create("u", "h", "Name");
        user.Deactivate();
        user.IsActive.Should().BeFalse();
    }

    [Fact]
    public void Activate_SetsIsActiveToTrue()
    {
        var user = User.Create("u", "h", "Name");
        user.Deactivate();
        user.Activate();
        user.IsActive.Should().BeTrue();
    }
}
