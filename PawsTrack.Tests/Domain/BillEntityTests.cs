using FluentAssertions;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Tests.Domain;

public class BillEntityTests
{
    // ── Create — property assignment ──────────────────────────────────────────

    [Fact]
    public void Create_WithValidData_SetsProperties()
    {
        var bill = Bill.Create(walkServiceId: 7, ratePerHour: 20m, discount: 0m, durationHours: 1.5);

        bill.WalkServiceId.Should().Be(7);
        bill.RatePerHour.Should().Be(20m);
        bill.Discount.Should().Be(0m);
        bill.TotalAmount.Should().Be(30m);   // 1.5h × $20
        bill.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    // ── Create — total amount calculation ────────────────────────────────────

    [Fact]
    public void Create_CalculatesTotalAs_DurationTimesRate_MinusDiscount()
    {
        // 2h × $25 = $50, minus $10 discount = $40
        var bill = Bill.Create(walkServiceId: 1, ratePerHour: 25m, discount: 10m, durationHours: 2.0);

        bill.TotalAmount.Should().Be(40m);
    }

    [Fact]
    public void Create_WhenDiscountExceedsGross_TotalAmountIsZero()
    {
        // 1h × $10 = $10, minus $50 discount → clamped to 0
        var bill = Bill.Create(walkServiceId: 1, ratePerHour: 10m, discount: 50m, durationHours: 1.0);

        bill.TotalAmount.Should().Be(0m);
    }

    [Fact]
    public void Create_WithZeroRate_TotalAmountIsZero()
    {
        var bill = Bill.Create(walkServiceId: 1, ratePerHour: 0m, discount: 0m, durationHours: 2.0);

        bill.TotalAmount.Should().Be(0m);
    }

    [Fact]
    public void Create_WithZeroDiscount_TotalIsFullDurationTimesRate()
    {
        var bill = Bill.Create(walkServiceId: 1, ratePerHour: 15m, discount: 0m, durationHours: 2.0);

        bill.TotalAmount.Should().Be(30m);
    }

    // ── Create — validation errors ────────────────────────────────────────────

    [Theory]
    [InlineData(-0.01)]
    [InlineData(-100)]
    public void Create_WithNegativeRatePerHour_ThrowsArgumentException(double rate)
    {
        var act = () => Bill.Create(1, (decimal)rate, 0m, 1.0);
        act.Should().Throw<ArgumentException>().WithParameterName("ratePerHour");
    }

    [Theory]
    [InlineData(-0.01)]
    [InlineData(-5)]
    public void Create_WithNegativeDiscount_ThrowsArgumentException(double discount)
    {
        var act = () => Bill.Create(1, 20m, (decimal)discount, 1.0);
        act.Should().Throw<ArgumentException>().WithParameterName("discount");
    }
}
