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

    // ── SearchClientsAsync ───────────────────────────────────────────────────

    [Fact]
    public async Task SearchClientsAsync_ReturnsMappedClientSummaryDtos()
    {
        var clients = new List<Client>
        {
            MakeClient(id: 1, fullName: "Jane Owner",  phone: "555-0001", address: "1 Main St"),
            MakeClient(id: 2, fullName: "John Walker", phone: "555-0002", address: "2 Oak Ave")
        };
        _clientRepoMock.Setup(r => r.SearchAsync("jane")).ReturnsAsync(clients);

        var result = await _sut.SearchClientsAsync("jane");

        result.Should().HaveCount(2);
        result[0].Id.Should().Be(1);
        result[0].FullName.Should().Be("Jane Owner");
        result[0].Phone.Should().Be("555-0001");
        result[0].Address.Should().Be("1 Main St");
    }

    [Fact]
    public async Task SearchClientsAsync_NullSearchTerm_PassesEmptyStringToRepository()
    {
        _clientRepoMock.Setup(r => r.SearchAsync(string.Empty)).ReturnsAsync(new List<Client>());

        await _sut.SearchClientsAsync(null!);

        _clientRepoMock.Verify(r => r.SearchAsync(string.Empty), Times.Once);
    }

    [Fact]
    public async Task SearchClientsAsync_NoMatches_ReturnsEmptyList()
    {
        _clientRepoMock.Setup(r => r.SearchAsync(It.IsAny<string>())).ReturnsAsync(new List<Client>());

        var result = await _sut.SearchClientsAsync("zzz");

        result.Should().BeEmpty();
    }

    // ── AddDogToExistingClientAsync ───────────────────────────────────────────

    [Fact]
    public async Task AddDogToExistingClientAsync_NullDogReq_ThrowsArgumentNullException()
    {
        var act = async () => await _sut.AddDogToExistingClientAsync(1, null!);
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task AddDogToExistingClientAsync_ClientNotFound_ThrowsArgumentException()
    {
        _clientRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Client?)null);

        var act = async () => await _sut.AddDogToExistingClientAsync(99, ValidDogReq());

        await act.Should().ThrowAsync<ArgumentException>().WithMessage("*99*");
        _dogRepoMock.Verify(r => r.AddAsync(It.IsAny<Dog>()), Times.Never);
    }

    [Fact]
    public async Task AddDogToExistingClientAsync_ValidRequest_AddsDogAndReturnsDto()
    {
        var client = MakeClient(id: 7, fullName: "Jane Owner");
        _clientRepoMock.Setup(r => r.GetByIdAsync(7)).ReturnsAsync(client);
        _dogRepoMock.Setup(r => r.AddAsync(It.IsAny<Dog>())).Returns(Task.CompletedTask);

        var result = await _sut.AddDogToExistingClientAsync(7, ValidDogReq());

        _dogRepoMock.Verify(r => r.AddAsync(It.IsAny<Dog>()), Times.Once);
        result.ClientId.Should().Be(7);
        result.ClientFullName.Should().Be("Jane Owner");
        result.DogName.Should().Be("Buddy");
    }

    [Fact]
    public async Task AddDogToExistingClientAsync_InvalidDogData_ThrowsArgumentException()
    {
        var client = MakeClient(id: 7);
        _clientRepoMock.Setup(r => r.GetByIdAsync(7)).ReturnsAsync(client);

        var act = async () => await _sut.AddDogToExistingClientAsync(7, new CreateDogRequest { Name = "", AgeYears = 2, Breed = "Poodle" });

        await act.Should().ThrowAsync<ArgumentException>();
        _dogRepoMock.Verify(r => r.AddAsync(It.IsAny<Dog>()), Times.Never);
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private static Client MakeClient(int id, string fullName = "Jane Owner", string phone = "555-1234", string address = "123 Main St")
    {
        var c = Client.Create(fullName, phone, address);
        typeof(Client).GetProperty("Id")!.SetValue(c, id);
        return c;
    }
}
