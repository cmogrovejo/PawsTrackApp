using FluentAssertions;
using Moq;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Application.Services;
using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;

namespace PawsTrack.Tests.Application;

public class BillingServiceTests
{
    private readonly Mock<IWalkServiceRepository> _walkRepoMock   = new();
    private readonly Mock<IClientRepository>      _clientRepoMock = new();
    private readonly Mock<IDogRepository>         _dogRepoMock    = new();
    private readonly Mock<IBillRepository>        _billRepoMock   = new();
    private readonly BillingService               _sut;

    public BillingServiceTests()
    {
        _sut = new BillingService(
            _walkRepoMock.Object,
            _clientRepoMock.Object,
            _dogRepoMock.Object,
            _billRepoMock.Object);
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

    /// <summary>Creates a WalkService with a controlled 2-hour duration.</summary>
    private static WalkService MakeWalk(int walkerId = 1, int clientId = 1, int dogId = 1)
    {
        var start = DateTime.Now.AddHours(1);
        var end   = start.AddHours(2);          // 2-hour walk
        return WalkService.Create(walkerId, clientId, dogId, start, end);
    }

    // ── SearchServicesAsync ───────────────────────────────────────────────────

    [Fact]
    public async Task SearchServicesAsync_AlwaysPassesCreatedStatusToRepository()
    {
        _walkRepoMock
            .Setup(r => r.SearchAsync(It.IsAny<string?>(), It.IsAny<DateTime?>(), WalkStatus.Created, It.IsAny<int?>()))
            .ReturnsAsync(new List<WalkService>());

        await _sut.SearchServicesAsync("Jane", DateTime.Today, walkerId: null);

        _walkRepoMock.Verify(
            r => r.SearchAsync("Jane", DateTime.Today, WalkStatus.Created, null),
            Times.Once);
    }

    [Fact]
    public async Task SearchServicesAsync_EnrichesResultsWithClientAndDogNames()
    {
        var walk   = MakeWalk(clientId: 1, dogId: 3);
        var client = MakeClient(id: 1, name: "Jane Owner");
        var dog    = MakeDog(id: 3, name: "Buddy", clientId: 1);

        _walkRepoMock
            .Setup(r => r.SearchAsync(It.IsAny<string?>(), It.IsAny<DateTime?>(), It.IsAny<WalkStatus?>(), It.IsAny<int?>()))
            .ReturnsAsync(new List<WalkService> { walk });
        _clientRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(client);
        _dogRepoMock.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(dog);

        var result = await _sut.SearchServicesAsync(null, null);

        result.Should().HaveCount(1);
        result[0].ClientName.Should().Be("Jane Owner");
        result[0].DogName.Should().Be("Buddy");
        result[0].Status.Should().Be("Created");
    }

    [Fact]
    public async Task SearchServicesAsync_NullClientAndDog_UsesFallbackNames()
    {
        var walk = MakeWalk(clientId: 7, dogId: 8);

        _walkRepoMock
            .Setup(r => r.SearchAsync(It.IsAny<string?>(), It.IsAny<DateTime?>(), It.IsAny<WalkStatus?>(), It.IsAny<int?>()))
            .ReturnsAsync(new List<WalkService> { walk });
        _clientRepoMock.Setup(r => r.GetByIdAsync(7)).ReturnsAsync((Client?)null);
        _dogRepoMock.Setup(r => r.GetByIdAsync(8)).ReturnsAsync((Dog?)null);

        var result = await _sut.SearchServicesAsync(null, null);

        result[0].ClientName.Should().Be("Client #7");
        result[0].DogName.Should().Be("Dog #8");
    }

    [Fact]
    public async Task SearchServicesAsync_CalculatesDurationHoursFromWalkTimes()
    {
        var walk   = MakeWalk(clientId: 1, dogId: 1);   // MakeWalk → 2-hour duration
        var client = MakeClient(id: 1);
        var dog    = MakeDog(id: 1, clientId: 1);

        _walkRepoMock
            .Setup(r => r.SearchAsync(It.IsAny<string?>(), It.IsAny<DateTime?>(), It.IsAny<WalkStatus?>(), It.IsAny<int?>()))
            .ReturnsAsync(new List<WalkService> { walk });
        _clientRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(client);
        _dogRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(dog);

        var result = await _sut.SearchServicesAsync(null, null);

        result[0].DurationHours.Should().BeApproximately(2.0, precision: 0.01);
    }

    // ── GetReportAsync ────────────────────────────────────────────────────────

    [Fact]
    public async Task GetReportAsync_DelegatesToBillRepository()
    {
        var from = new DateTime(2025, 1, 1);
        var to   = new DateTime(2025, 1, 31);
        var rows = new List<BillReportRowDto>();

        _billRepoMock
            .Setup(r => r.GetReportAsync("Jane", from, to, 2))
            .ReturnsAsync(rows);

        var result = await _sut.GetReportAsync("Jane", from, to, walkerId: 2);

        result.Should().BeSameAs(rows);
        _billRepoMock.Verify(r => r.GetReportAsync("Jane", from, to, 2), Times.Once);
    }

    // ── CreateBillAsync ───────────────────────────────────────────────────────

    [Fact]
    public async Task CreateBillAsync_WalkNotFound_ThrowsInvalidOperationException()
    {
        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((WalkService?)null);

        var act = async () => await _sut.CreateBillAsync(new CreateBillRequest(42, 20m, 0m));

        await act.Should().ThrowAsync<InvalidOperationException>().WithMessage("*42*");
    }

    [Fact]
    public async Task CreateBillAsync_WalkAlreadyCompleted_ThrowsInvalidOperationException()
    {
        var walk = MakeWalk();
        walk.Complete();    // Status → Completed

        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(walk);

        var act = async () => await _sut.CreateBillAsync(new CreateBillRequest(1, 20m, 0m));

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*created walks*");
    }

    [Fact]
    public async Task CreateBillAsync_ValidRequest_SavesBillAndMarksWalkAsCompleted()
    {
        var walk = MakeWalk();

        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(walk);
        _billRepoMock.Setup(r => r.AddAsync(It.IsAny<Bill>())).Returns(Task.CompletedTask);
        _walkRepoMock.Setup(r => r.UpdateAsync(It.IsAny<WalkService>())).Returns(Task.CompletedTask);

        await _sut.CreateBillAsync(new CreateBillRequest(WalkServiceId: 1, RatePerHour: 20m, Discount: 0m));

        _billRepoMock.Verify(r => r.AddAsync(It.IsAny<Bill>()), Times.Once);
        _walkRepoMock.Verify(r => r.UpdateAsync(walk), Times.Once);
        walk.Status.Should().Be(WalkStatus.Completed);
    }

    [Fact]
    public async Task CreateBillAsync_ValidRequest_ReturnsBillDtoWithCorrectTotalAmount()
    {
        var walk = MakeWalk();  // 2-hour duration

        _walkRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(walk);
        _billRepoMock.Setup(r => r.AddAsync(It.IsAny<Bill>())).Returns(Task.CompletedTask);
        _walkRepoMock.Setup(r => r.UpdateAsync(It.IsAny<WalkService>())).Returns(Task.CompletedTask);

        // 2h × $25 − $5 = $45
        var result = await _sut.CreateBillAsync(new CreateBillRequest(WalkServiceId: 1, RatePerHour: 25m, Discount: 5m));

        result.RatePerHour.Should().Be(25m);
        result.Discount.Should().Be(5m);
        result.TotalAmount.Should().BeApproximately(45m, precision: 0.01m);
    }
}
