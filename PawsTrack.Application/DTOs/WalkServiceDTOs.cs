namespace PawsTrack.Application.DTOs
{
    public class CreateWalkServiceRequest
    {
        public int      WalkerId  { get; init; }
        public int      ClientId  { get; init; }
        public int      DogId     { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime   { get; init; }
    }

    public class WalkServiceCreatedDto
    {
        public int      Id         { get; init; }
        public string   ClientName { get; init; } = string.Empty;
        public string   DogName    { get; init; } = string.Empty;
        public DateTime StartTime  { get; init; }
        public DateTime EndTime    { get; init; }
        public string   Status     { get; init; } = string.Empty;
    }

    public class DogSummaryDto
    {
        public int    Id   { get; init; }
        public string Name { get; init; } = string.Empty;
    }

    public class UpdateWalkServiceRequest
    {
        public int      Id        { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime   { get; init; }
    }
}
