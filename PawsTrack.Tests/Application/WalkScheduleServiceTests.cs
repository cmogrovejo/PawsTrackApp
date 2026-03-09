using FluentAssertions;
using Moq;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Application.Services;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Tests.Application;

public class WalkScheduleServiceTests
{
    private readonly Mock<IWalkServiceRepository> _walkRepoMock   = new();
    private readonly Mock<IClientRepository>      _clientRepoMock = new();
    private readonly Mock<IDogRepository>         _dogRepoMock    = new();
    private readonly WalkScheduleService          _sut;

    public WalkScheduleServiceTests()
    {
        _sut = new WalkScheduleService(
            _walkRepoMock.Object,
            _clientRepoMock.Object,
            _dogRepoMock.Object);
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static Client MakeClient(int id = 1, string name = "Jane Owner")
    {
        var c = Client.Create(name, "555-1234", "123 Main St");
        typeof(Client).GetProperty("Id")!.SetValue(c, id);
        return c;
    }

    private static Dog MakeDog(int id = 1, string name = "Buddy", int clientId = 1)
    {
        var d = Dog.Create(name, 3, "Golden Retriever", null, clientId);
        typeof(Dog).GetProperty("Id")!.SetValue(d, id);
        return d;
    }

    private static WalkService MakeWalk(int walkerId = 1, int clientId = 1, int dogId = 1)
        => WalkService.Create(walkerId, clientId, dogId,
               DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

    private static CreateWalkServiceRequest ValidRequest(int clientId = 1, int dogId = 1) => new()
    {
        WalkerId  = 1,
        ClientId  = clientId,
        DogId     = dogId,
        StartTime = DateTime.Now.AddHours(1),
        EndTime   = DateTime.Now.AddHours(2)
    };

    // ── CreateAsync ───────────────────────────────────────────────────────────

    [Fact]
    public async Task CreateAsync_NullRequest_ThrowsArgumentNullException()
    {
        var act = async () => await _sut.CreateAsync(null!);
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task CreateAsync_ClientNotFound_ThrowsArgumentException()
    {
        _clientRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Client?)null);

        var act = async () => await _sut.CreateAsync(ValidRequest());

        await act.Should().ThrowAsync<ArgumentException>().WithMessage("*Client*");
    }

    [Fact]
    public async Task CreateAsync_DogNotFound_ThrowsArgumentException()
    {
        _clientRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(MakeClient(1));
        _dogRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Dog?)null);

        var act = async () => await _sut.CreateAsync(ValidRequest(clientId: 1, dogId: 99));

        await act.Should().ThrowAsync<ArgumentException>().WithMessage("*Dog*");
    }

    [Fact]
    public async Task CreateAsync_DogBelongsToOtherClient_ThrowsArgumentException()
    {
        var client = MakeClient(id: 1);
        var dog    = MakeDog(id: 5, clientId: 99);  // dog.ClientId != client.Id

        _clientRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(client);
        _dogRepoMock.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(dog);

        var act = async () => await _sut.CreateAsync(ValidRequest(clientId: 1, dogId: 5));

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("*does not belong*");
    }

    [Fact]
    public async Task CreateAsync_ValidRequest_AddsWalkAndReturnsDto()
    {
        var client = MakeClient(id: 1, name: "Jane Owner");
        var dog    = MakeDog(id: 3, name: "Buddy", clientId: 1);

        _clientRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(client);
        _dogRepoMock.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(dog);
        _walkRepoMock.Setup(r => r.AddAsync(It.IsAny<WalkService>())).Returns(Task.CompletedTask);

        var result = await _sut.CreateAsync(ValidRequest(clientId: 1, dogId: 3));

        _walkRepoMock.Verify(r => r.AddAsync(It.IsAny<WalkService>()), Times.Once);
        result.ClientName.Should().Be("Jane Owner");
        result.DogName.Should().Be("Buddy");
        result.Status.Should().Be("Created");
    }

    // ── GetDogsByClientAsync ──────────────────────────────────────────────────

    [Fact]
    public async Task GetDogsByClientAsync_ReturnsMappedDogSummaryDtos()
    {
        var dogs = new List<Dog>
        {
            MakeDog(id: 1, name: "Buddy", clientId: 5),
            MakeDog(id: 2, name: "Max",   clientId: 5)
        };
        _dogRepoMock.Setup(r => r.GetByClientIdAsync(5)).ReturnsAsync(dogs);

        var result = await _sut.GetDogsByClientAsync(5);

        result.Should().HaveCount(2);
        result.Should().ContainSingle(d => d.Id == 1 && d.Name == "Buddy");
        result.Should().ContainSingle(d => d.Id == 2 && d.Name == "Max");
    }

    [Fact]
    public async Task GetDogsByClientAsync_NoDogs_ReturnsEmptyList()
    {
        _dogRepoMock.Setup(r => r.GetByClientIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new List<Dog>());

        var result = await _sut.GetDogsByClientAsync(99);

        result.Should().BeEmpty();
    }

    // ── GetByDateAsync ────────────────────────────────────────────────────────

    [Fact]
    public async Task GetByDateAsync_NoWalks_ReturnsEmptyList()
    {
        _walkRepoMock.Setup(r => r.GetByDateAsync(It.IsAny<DateTime>(), It.IsAny<int?>()))
            .ReturnsAsync(new List<WalkService>());

        var result = await _sut.GetByDateAsync(DateTime.Today);

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetByDateAsync_WithWalks_ReturnsEnrichedDtos()
    {
        var walk   = MakeWalk(walkerId: 1, clientId: 1, dogId: 3);
        var client = MakeClient(id: 1, name: "Jane Owner");
        var dog    = MakeDog(id: 3, name: "Buddy", clientId: 1);

        _walkRepoMock.Setup(r => r.GetByDateAsync(It.IsAny<DateTime>(), It.IsAny<int?>()))
            .ReturnsAsync(new List<WalkService> { walk });
        _clientRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(client);
        _dogRepoMock.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(dog);

        var result = await _sut.GetByDateAsync(DateTime.Today);

        result.Should().HaveCount(1);
        result[0].ClientName.Should().Be("Jane Owner");
        result[0].DogName.Should().Be("Buddy");
        result[0].Status.Should().Be("Created");
    }

    [Fact]
    public async Task GetByDateAsync_ClientOrDogNotFound_UsesFallbackNames()
    {
        var walk = MakeWalk(walkerId: 1, clientId: 7, dogId: 8);

        _walkRepoMock.Setup(r => r.GetByDateAsync(It.IsAny<DateTime>(), It.IsAny<int?>()))
            .ReturnsAsync(new List<WalkService> { walk });
        _clientRepoMock.Setup(r => r.GetByIdAsync(7)).ReturnsAsync((Client?)null);
        _dogRepoMock.Setup(r => r.GetByIdAsync(8)).ReturnsAsync((Dog?)null);

        var result = await _sut.GetByDateAsync(DateTime.Today);

        result[0].ClientName.Should().Be("Client #7");
        result[0].DogName.Should().Be("Dog #8");
    }

    // ── UpdateAsync ───────────────────────────────────────────────────────────

    [Fact]
    public async Task UpdateAsync_NullRequest_ThrowsArgumentNullException()
    {
        var act = async () => await _sut.UpdateAsync(null!);
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task UpdateAsync_WalkNotFound_ThrowsArgumentException()
    {
        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((WalkService?)null);

        var act = async () => await _sut.UpdateAsync(new UpdateWalkServiceRequest
        {
            Id        = 99,
            StartTime = DateTime.Now.AddHours(3),
            EndTime   = DateTime.Now.AddHours(4)
        });

        await act.Should().ThrowAsync<ArgumentException>().WithMessage("*99*");
    }

    [Fact]
    public async Task UpdateAsync_ValidRequest_ReschedulesAndCallsUpdateOnRepository()
    {
        var walk     = MakeWalk();
        var newStart = DateTime.Now.AddDays(1);
        var newEnd   = newStart.AddHours(2);

        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(walk);
        _walkRepoMock.Setup(r => r.UpdateAsync(It.IsAny<WalkService>())).Returns(Task.CompletedTask);

        await _sut.UpdateAsync(new UpdateWalkServiceRequest { Id = 1, StartTime = newStart, EndTime = newEnd });

        _walkRepoMock.Verify(r => r.UpdateAsync(walk), Times.Once);
        walk.StartTime.Should().Be(newStart);
        walk.EndTime.Should().Be(newEnd);
    }

    // ── DeleteAsync ───────────────────────────────────────────────────────────

    [Fact]
    public async Task DeleteAsync_WalkNotFound_ThrowsArgumentException()
    {
        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((WalkService?)null);

        var act = async () => await _sut.DeleteAsync(55);

        await act.Should().ThrowAsync<ArgumentException>().WithMessage("*55*");
    }

    [Fact]
    public async Task DeleteAsync_WalkAlreadyCompleted_ThrowsInvalidOperationException()
    {
        var walk = MakeWalk();
        walk.Complete();   // Status → Completed

        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(walk);

        var act = async () => await _sut.DeleteAsync(1);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*Created*");
    }

    [Fact]
    public async Task DeleteAsync_WalkInCreatedStatus_CallsDeleteOnRepository()
    {
        var walk = MakeWalk();

        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(walk);
        _walkRepoMock.Setup(r => r.DeleteAsync(It.IsAny<WalkService>())).Returns(Task.CompletedTask);

        await _sut.DeleteAsync(1);

        _walkRepoMock.Verify(r => r.DeleteAsync(walk), Times.Once);
    }
}
