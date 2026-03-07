namespace PawsTrack.Domain.Entities
{
    public class Dog
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int AgeYears { get; private set; }
        public string Breed { get; private set; }
        public string? MedicalNotes { get; private set; }
        public int ClientId { get; private set; }
        public Client Client { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Dog()
        {
            Name = string.Empty;
            Breed = string.Empty;
            Client = null!;
        }

        private Dog(string name, int ageYears, string breed, string? medicalNotes, int clientId)
        {
            Name = name;
            AgeYears = ageYears;
            Breed = breed;
            MedicalNotes = medicalNotes;
            ClientId = clientId;
            CreatedAt = DateTime.UtcNow;
            Client = null!;
        }

        public static Dog Create(string name, int ageYears, string breed, string? medicalNotes, int clientId)
        {
            name  = name?.Trim()  ?? throw new ArgumentException("Name cannot be empty.", nameof(name));
            breed = breed?.Trim() ?? throw new ArgumentException("Breed cannot be empty.", nameof(breed));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(breed))
                throw new ArgumentException("Breed cannot be empty.", nameof(breed));
            if (ageYears < 0 || ageYears > 30)
                throw new ArgumentException("Age must be between 0 and 30.", nameof(ageYears));
            if (clientId <= 0)
                throw new ArgumentException("ClientId must be greater than zero.", nameof(clientId));

            return new Dog(name, ageYears, breed, medicalNotes, clientId);
        }
    }
}
