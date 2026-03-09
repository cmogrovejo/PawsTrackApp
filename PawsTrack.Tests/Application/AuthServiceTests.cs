using FluentAssertions;
using Moq;
using PawsTrack.Application.Interfaces;
using PawsTrack.Application.Services;
using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;

namespace PawsTrack.Tests.Application;

/// <summary>
/// Unit tests for AuthService.
/// Dependencies (IUserRepository, IPasswordHasher) are mocked with Moq
/// so tests run in memory with no DB connection required.
/// </summary>
public class AuthServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock;
    private readonly Mock<IPasswordHasher> _hasherMock;
    private readonly AuthService _sut;

    public AuthServiceTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _hasherMock = new Mock<IPasswordHasher>();
        _sut = new AuthService(_userRepoMock.Object, _hasherMock.Object);
    }

    // ── Happy path ─────────────────────────────────────────────────────────

    [Fact]
    public async Task LoginAsync_ValidCredentials_ReturnsSuccess()
    {
        var user = User.Create("walker1", "hashed", "Jane Walker");
        _userRepoMock.Setup(r => r.GetByUsernameAsync("walker1")).ReturnsAsync(user);
        _hasherMock.Setup(h => h.Verify("Password1", "hashed")).Returns(true);

        var result = await _sut.LoginAsync("walker1", "Password1");

        result.Success.Should().BeTrue();
        result.User!.Username.Should().Be("walker1");
        result.User.FullName.Should().Be("Jane Walker");
        result.ErrorMessage.Should().BeNull();
    }

    [Fact]
    public async Task LoginAsync_ValidCredentials_UpdatesLastLoginAt()
    {
        var user = User.Create("walker1", "hashed", "Jane Walker");
        _userRepoMock.Setup(r => r.GetByUsernameAsync("walker1")).ReturnsAsync(user);
        _hasherMock.Setup(h => h.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

        await _sut.LoginAsync("walker1", "Password1");

        // UpdateAsync must be called to persist the LastLoginAt change
        _userRepoMock.Verify(r => r.UpdateAsync(It.IsAny<User>()), Times.Once);
    }

    // ── Invalid credentials ────────────────────────────────────────────────

    [Fact]
    public async Task LoginAsync_WrongPassword_ReturnsFailure()
    {
        var user = User.Create("walker1", "hashed", "Jane Walker");
        _userRepoMock.Setup(r => r.GetByUsernameAsync("walker1")).ReturnsAsync(user);
        _hasherMock.Setup(h => h.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

        var result = await _sut.LoginAsync("walker1", "WrongPass");

        result.Success.Should().BeFalse();
        result.ErrorMessage.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task LoginAsync_UnknownUsername_ReturnsGenericError()
    {
        _userRepoMock.Setup(r => r.GetByUsernameAsync(It.IsAny<string>())).ReturnsAsync((User?)null);

        var result = await _sut.LoginAsync("unknown", "anypass");

        result.Success.Should().BeFalse();
        // Must NOT reveal whether the user exists (security: enumeration prevention)
        result.ErrorMessage.Should().Be("Invalid username or password.");
    }

    // ── Input validation ───────────────────────────────────────────────────

    [Theory]
    [InlineData("", "password")]
    [InlineData("   ", "password")]
    [InlineData("user", "")]
    [InlineData("user", "   ")]
    public async Task LoginAsync_EmptyInputs_ReturnsFailureWithoutHittingRepo(string username, string password)
    {
        var result = await _sut.LoginAsync(username, password);

        result.Success.Should().BeFalse();
        _userRepoMock.Verify(r => r.GetByUsernameAsync(It.IsAny<string>()), Times.Never);
    }

    // ── Lockout ────────────────────────────────────────────────────────────

    [Fact]
    public async Task LoginAsync_LockedAccount_ReturnsLockedMessage()
    {
        var user = User.Create("walker1", "hashed", "Jane Walker");
        // Trigger lockout via domain rule
        for (int i = 0; i < 5; i++) user.RecordFailedLoginAttempt();

        _userRepoMock.Setup(r => r.GetByUsernameAsync("walker1")).ReturnsAsync(user);

        var result = await _sut.LoginAsync("walker1", "anypass");

        result.Success.Should().BeFalse();
        result.ErrorMessage.Should().Contain("locked");
        // Should NOT call Verify — we bail before checking the password
        _hasherMock.Verify(h => h.Verify(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task LoginAsync_WrongPassword_IncrementsFailedAttempts()
    {
        var user = User.Create("walker1", "hashed", "Jane Walker");
        _userRepoMock.Setup(r => r.GetByUsernameAsync("walker1")).ReturnsAsync(user);
        _hasherMock.Setup(h => h.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

        await _sut.LoginAsync("walker1", "Wrong");

        user.FailedLoginAttempts.Should().Be(1);
        _userRepoMock.Verify(r => r.UpdateAsync(user), Times.Once);
    }

    // ── Deactivated account ────────────────────────────────────────────────

    [Fact]
    public async Task LoginAsync_DeactivatedUser_ReturnsDeactivatedMessage()
    {
        var user = User.Create("walker1", "hashed", "Jane Walker");
        user.Deactivate();

        _userRepoMock.Setup(r => r.GetByUsernameAsync("walker1")).ReturnsAsync(user);

        var result = await _sut.LoginAsync("walker1", "Password1");

        result.Success.Should().BeFalse();
        result.ErrorMessage.Should().Contain("deactivated");
    }

    // ── Initial admin setup ────────────────────────────────────────────────

    [Fact]
    public async Task CreateInitialAdminAsync_WhenNoUsersExist_CreatesUser()
    {
        _userRepoMock.Setup(r => r.AnyExistsAsync()).ReturnsAsync(false);
        _hasherMock.Setup(h => h.Hash(It.IsAny<string>())).Returns("hashed");

        var result = await _sut.CreateInitialAdminAsync("admin", "SecurePass1", "Admin User");

        result.Should().BeTrue();
        _userRepoMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task CreateInitialAdminAsync_WhenUsersExist_ThrowsInvalidOperation()
    {
        _userRepoMock.Setup(r => r.AnyExistsAsync()).ReturnsAsync(true);

        var act = async () => await _sut.CreateInitialAdminAsync("admin", "SecurePass1", "Admin");

        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Theory]
    [InlineData("short1")]        // Too short
    [InlineData("alllowercase1")] // No uppercase
    [InlineData("NoNumbers")]     // No digit
    public async Task CreateInitialAdminAsync_WeakPassword_ThrowsArgumentException(string weakPassword)
    {
        _userRepoMock.Setup(r => r.AnyExistsAsync()).ReturnsAsync(false);

        var act = async () => await _sut.CreateInitialAdminAsync("admin", weakPassword, "Admin");

        await act.Should().ThrowAsync<ArgumentException>();
    }

    // ── Walker registration ────────────────────────────────────────────────

    [Fact]
    public async Task CreateWalkerAsync_ValidData_CreatesWalkerUser()
    {
        _userRepoMock.Setup(r => r.GetByUsernameAsync("newwalker")).ReturnsAsync((User?)null);
        _hasherMock.Setup(h => h.Hash(It.IsAny<string>())).Returns("hashed");

        var result = await _sut.CreateWalkerAsync("newwalker", "SecurePass1", "New Walker");

        result.Should().BeTrue();
        _userRepoMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task CreateWalkerAsync_DuplicateUsername_ThrowsArgumentException()
    {
        var existing = User.Create("walker1", "hashed", "Existing Walker");
        _userRepoMock.Setup(r => r.GetByUsernameAsync("walker1")).ReturnsAsync(existing);

        var act = async () => await _sut.CreateWalkerAsync("walker1", "SecurePass1", "New Walker");

        await act.Should().ThrowAsync<ArgumentException>().WithMessage("*already taken*");
        _userRepoMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Never);
    }

    [Theory]
    [InlineData("short1")]        // Too short
    [InlineData("alllowercase1")] // No uppercase
    [InlineData("NoNumbers")]     // No digit
    public async Task CreateWalkerAsync_WeakPassword_ThrowsArgumentException(string weakPassword)
    {
        _userRepoMock.Setup(r => r.GetByUsernameAsync(It.IsAny<string>())).ReturnsAsync((User?)null);

        var act = async () => await _sut.CreateWalkerAsync("walker1", weakPassword, "New Walker");

        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task CreateWalkerAsync_EmptyUsername_ThrowsArgumentException()
    {
        var act = async () => await _sut.CreateWalkerAsync("   ", "SecurePass1", "New Walker");

        await act.Should().ThrowAsync<ArgumentException>();
        _userRepoMock.Verify(r => r.GetByUsernameAsync(It.IsAny<string>()), Times.Never);
    }

    // ── Password reset ─────────────────────────────────────────────────────

    [Fact]
    public async Task ResetUserPasswordAsync_ValidUser_UpdatesPasswordHash()
    {
        var user = User.Create("walker1", "oldhash", "Jane Walker");
        _userRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);
        _hasherMock.Setup(h => h.Hash("NewPass1")).Returns("newhash");

        var result = await _sut.ResetUserPasswordAsync(1, "NewPass1");

        result.Should().BeTrue();
        _userRepoMock.Verify(r => r.UpdateAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task ResetUserPasswordAsync_UserNotFound_ReturnsFalse()
    {
        _userRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((User?)null);

        var result = await _sut.ResetUserPasswordAsync(99, "NewPass1");

        result.Should().BeFalse();
    }

    // ── GetWalkersAsync ────────────────────────────────────────────────────

    [Fact]
    public async Task GetWalkersAsync_ReturnsOnlyUsersWithWalkerRole()
    {
        var users = new List<User>
        {
            User.Create("admin1",   "h", "Admin One",   UserRole.Admin),
            User.Create("walker1",  "h", "Alice Smith",  UserRole.Walker),
            User.Create("walker2",  "h", "Bob Jones",    UserRole.Walker)
        };
        _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        var result = await _sut.GetWalkersAsync();

        result.Should().HaveCount(2);
        result.Should().NotContain(u => u.Username == "admin1");
    }

    [Fact]
    public async Task GetWalkersAsync_ResultsAreOrderedByFullName()
    {
        var users = new List<User>
        {
            User.Create("charlie", "h", "Charlie Brown", UserRole.Walker),
            User.Create("alice",   "h", "Alice Smith",   UserRole.Walker),
            User.Create("bob",     "h", "Bob Jones",     UserRole.Walker)
        };
        _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        var result = await _sut.GetWalkersAsync();

        result.Select(u => u.FullName).Should().BeInAscendingOrder();
    }

    [Fact]
    public async Task GetWalkersAsync_WithSearchTerm_FiltersOnFullNameAndUsername()
    {
        var users = new List<User>
        {
            User.Create("alice",  "h", "Alice Smith", UserRole.Walker),
            User.Create("robert", "h", "Robert King", UserRole.Walker)
        };
        _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        // Match on full name
        var byName = await _sut.GetWalkersAsync("alice");
        byName.Should().ContainSingle(u => u.Username == "alice");

        // Match on username
        var byUsername = await _sut.GetWalkersAsync("robert");
        byUsername.Should().ContainSingle(u => u.Username == "robert");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task GetWalkersAsync_WithBlankSearch_ReturnsAllWalkers(string? search)
    {
        var users = new List<User>
        {
            User.Create("walker1", "h", "Alice Smith", UserRole.Walker),
            User.Create("walker2", "h", "Bob Jones",   UserRole.Walker)
        };
        _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        var result = await _sut.GetWalkersAsync(search);

        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetWalkersAsync_NoWalkersExist_ReturnsEmptyList()
    {
        var users = new List<User>
        {
            User.Create("admin1", "h", "Admin One", UserRole.Admin)
        };
        _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        var result = await _sut.GetWalkersAsync();

        result.Should().BeEmpty();
    }
}
