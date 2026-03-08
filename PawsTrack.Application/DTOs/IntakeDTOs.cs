namespace PawsTrack.Application.DTOs
{
    public class CreateClientRequest
    {
        public string FullName { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
    }

    public class CreateDogRequest
    {
        public string Name { get; init; } = string.Empty;
        public int AgeYears { get; init; }
        public string Breed { get; init; } = string.Empty;
        public string? MedicalNotes { get; init; }
    }

    public class ClientCreatedDto
    {
        public int ClientId { get; init; }
        public string ClientFullName { get; init; } = string.Empty;
        public int DogId { get; init; }
        public string DogName { get; init; } = string.Empty;
    }

    public class ClientSummaryDto
    {
        public int Id { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
    }
}
