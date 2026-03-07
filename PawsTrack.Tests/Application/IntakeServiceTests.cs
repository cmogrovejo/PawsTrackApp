using FluentAssertions;
using Moq;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Application.Services;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Tests.Application;

public class IntakeServiceTests
{
    private readonly Mock<IClientRepository> _clientRepoMock;
    private readonly Mock<IDogRepository> _dogRepoMock;
    private readonly IntakeService _sut;

    public IntakeServiceTests()
    {
        _clientRepoMock = new Mock<IClientRepository>();
        _dogRepoMock    = new Mock<IDogRepository>();
        _sut = new IntakeService(_clientRepoMock.Object, _dogRepoMock.Object);
    }

    private static CreateClientRequest ValidClientReq() => new()
    {
        FullName = "Jane Owner",
        Phone    = "555-1234",
        Address  = "123 Main St"
    };

    private static CreateDogRequest ValidDogReq() => new()
    {
        Name     = "Buddy",
        AgeYears = 3,
        Breed    = "Golden Retriever"
    };

    // ── Happy path ──────────────────────────────────────────────────────────

    [Fact]
    public async Task CreateClientWithDogAsync_HappyPath_CallsAddAsyncOnBothRepos()
    {
        // Simulate EF assigning Id after SaveChangesAsync
        _clientRepoMock
            .Setup(r => r.AddAsync(It.IsAny<Client>()))
            .Callback<Client>(c => typeof(Client).GetProperty("Id")!.SetValue(c, 42))
            .Returns(Task.CompletedTask);

        var result = await _sut.CreateClientWithDogAsync(ValidClientReq(), ValidDogReq());

        _clientRepoMock.Verify(r => r.AddAsync(It.IsAny<Client>()), Times.Once);
        _dogRepoMock.Verify(r => r.AddAsync(It.IsAny<Dog>()), Times.Once);
        result.ClientFullName.Should().Be("Jane Owner");
        result.DogName.Should().Be("Buddy");
        result.ClientId.Should().Be(42);
    }

    // ── Null requests ───────────────────────────────────────────────────────

    [Fact]
    public async Task CreateClientWithDogAsync_NullClientReq_ThrowsArgumentNullException()
    {
        var act = async () => await _sut.CreateClientWithDogAsync(null!, ValidDogReq());
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task CreateClientWithDogAsync_NullDogReq_ThrowsArgumentNullException()
    {
        var act = async () => await _sut.CreateClientWithDogAsync(ValidClientReq(), null!);
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    // ── Domain validation: invalid client ───────────────────────────────────

    [Fact]
    public async Task CreateClientWithDogAsync_InvalidClientData_ThrowsBeforeAnyAddAsync()
    {
        var badClientReq = new CreateClientRequest { FullName = "", Phone = "555", Address = "Addr" };

        var act = async () => await _sut.CreateClientWithDogAsync(badClientReq, ValidDogReq());

        await act.Should().ThrowAsync<ArgumentException>();
        _clientRepoMock.Verify(r => r.AddAsync(It.IsAny<Client>()), Times.Never);
        _dogRepoMock.Verify(r => r.AddAsync(It.IsAny<Dog>()), Times.Never);
    }

    // ── Domain validation: invalid dog data ─────────────────────────────────

    [Fact]
    public async Task CreateClientWithDogAsync_InvalidDogData_ClientAddCalledOnce_DogAddNotCalled()
    {
        var badDogReq = new CreateDogRequest { Name = "", AgeYears = 2, Breed = "Poodle" };

        var act = async () => await _sut.CreateClientWithDogAsync(ValidClientReq(), badDogReq);

        await act.Should().ThrowAsync<ArgumentException>();
        _clientRepoMock.Verify(r => r.AddAsync(It.IsAny<Client>()), Times.Once);
        _dogRepoMock.Verify(r => r.AddAsync(It.IsAny<Dog>()), Times.Never);
    }
}
