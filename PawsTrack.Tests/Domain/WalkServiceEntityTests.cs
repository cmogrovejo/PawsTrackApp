using FluentAssertions;
using PawsTrack.Domain.Entities;
using PawsTrack.Domain.Enums;

namespace PawsTrack.Tests.Domain;

public class WalkServiceEntityTests
{
    private static DateTime FutureStart => DateTime.Now.AddHours(1);
    private static DateTime FutureEnd   => DateTime.Now.AddHours(2);

    // ── Create ──────────────────────────────────────────────────────────────

    [Fact]
    public void Create_WithValidData_SetsProperties()
    {
        var start = FutureStart;
        var end   = FutureEnd;

        var walk = WalkService.Create(1, 2, 3, start, end);

        walk.WalkerId.Should().Be(1);
        walk.ClientId.Should().Be(2);
        walk.DogId.Should().Be(3);
        walk.StartTime.Should().Be(start);
        walk.EndTime.Should().Be(end);
        walk.Status.Should().Be(WalkStatus.Created);
        walk.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(5));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Create_WithInvalidWalkerId_ThrowsArgumentException(int walkerId)
    {
        var act = () => WalkService.Create(walkerId, 2, 3, FutureStart, FutureEnd);
        act.Should().Throw<ArgumentException>().WithParameterName("walkerId");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Create_WithInvalidClientId_ThrowsArgumentException(int clientId)
    {
        var act = () => WalkService.Create(1, clientId, 3, FutureStart, FutureEnd);
        act.Should().Throw<ArgumentException>().WithParameterName("clientId");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-3)]
    public void Create_WithInvalidDogId_ThrowsArgumentException(int dogId)
    {
        var act = () => WalkService.Create(1, 2, dogId, FutureStart, FutureEnd);
        act.Should().Throw<ArgumentException>().WithParameterName("dogId");
    }

    [Fact]
    public void Create_WithPastStartTime_ThrowsArgumentException()
    {
        var pastStart = DateTime.Now.AddHours(-1);

        var act = () => WalkService.Create(1, 2, 3, pastStart, FutureEnd);

        act.Should().Throw<ArgumentException>().WithParameterName("startTime");
    }

    [Fact]
    public void Create_WithEndTimeBeforeStartTime_ThrowsArgumentException()
    {
        var start = FutureStart;
        var end   = start.AddMinutes(-30);

        var act = () => WalkService.Create(1, 2, 3, start, end);

        act.Should().Throw<ArgumentException>().WithParameterName("endTime");
    }

    [Fact]
    public void Create_WithEndTimeEqualToStartTime_ThrowsArgumentException()
    {
        var start = FutureStart;

        var act = () => WalkService.Create(1, 2, 3, start, start);

        act.Should().Throw<ArgumentException>().WithParameterName("endTime");
    }

    // ── Complete ─────────────────────────────────────────────────────────────

    [Fact]
    public void Complete_WhenCreated_SetsStatusToCompleted()
    {
        var walk = WalkService.Create(1, 2, 3, FutureStart, FutureEnd);

        walk.Complete();

        walk.Status.Should().Be(WalkStatus.Completed);
    }

    [Fact]
    public void Complete_WhenAlreadyCompleted_ThrowsInvalidOperationException()
    {
        var walk = WalkService.Create(1, 2, 3, FutureStart, FutureEnd);
        walk.Complete();

        var act = () => walk.Complete();

        act.Should().Throw<InvalidOperationException>()
            .WithMessage("*already completed*");
    }

    // ── Reschedule ───────────────────────────────────────────────────────────

    [Fact]
    public void Reschedule_WhenCreated_UpdatesStartAndEndTime()
    {
        var walk     = WalkService.Create(1, 2, 3, FutureStart, FutureEnd);
        var newStart = DateTime.Now.AddDays(1);
        var newEnd   = newStart.AddHours(2);

        walk.Reschedule(newStart, newEnd);

        walk.StartTime.Should().Be(newStart);
        walk.EndTime.Should().Be(newEnd);
        walk.Status.Should().Be(WalkStatus.Created);
    }

    [Fact]
    public void Reschedule_WhenCompleted_ThrowsInvalidOperationException()
    {
        var walk = WalkService.Create(1, 2, 3, FutureStart, FutureEnd);
        walk.Complete();

        var act = () => walk.Reschedule(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(1));

        act.Should().Throw<InvalidOperationException>()
            .WithMessage("*Created*");
    }

    [Fact]
    public void Reschedule_WithPastStartTime_ThrowsArgumentException()
    {
        var walk = WalkService.Create(1, 2, 3, FutureStart, FutureEnd);

        var act = () => walk.Reschedule(DateTime.Now.AddHours(-1), FutureEnd);

        act.Should().Throw<ArgumentException>().WithParameterName("newStart");
    }

    [Fact]
    public void Reschedule_WithEndTimeBeforeNewStart_ThrowsArgumentException()
    {
        var walk     = WalkService.Create(1, 2, 3, FutureStart, FutureEnd);
        var newStart = DateTime.Now.AddHours(3);
        var badEnd   = newStart.AddMinutes(-10);

        var act = () => walk.Reschedule(newStart, badEnd);

        act.Should().Throw<ArgumentException>().WithParameterName("newEnd");
    }
}
