namespace PawsTrack.Application.DTOs
{
    public record BillableServiceDto(
        int      WalkServiceId,
        string   ClientName,
        string   DogName,
        DateTime StartTime,
        DateTime EndTime,
        string   Status,
        double   DurationHours);

    public record CreateBillRequest(
        int     WalkServiceId,
        decimal RatePerHour,
        decimal Discount);

    public record BillDto(
        int      Id,
        int      WalkServiceId,
        decimal  RatePerHour,
        decimal  Discount,
        decimal  TotalAmount,
        DateTime CreatedAt);

    public record BillReportRowDto(
        string   ClientName,
        string   DogName,
        DateTime WalkDate,
        DateTime StartTime,
        DateTime EndTime,
        double   DurationHours,
        decimal  RatePerHour,
        decimal  Discount,
        decimal  TotalAmount,
        DateTime BilledAt);
}
