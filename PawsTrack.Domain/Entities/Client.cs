namespace PawsTrack.Domain.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<Dog> _dogs;
        public IReadOnlyCollection<Dog> Dogs => _dogs.AsReadOnly();

        private Client()
        {
            FullName = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
            _dogs = new List<Dog>();
        }

        private Client(string fullName, string phone, string address)
        {
            FullName = fullName;
            Phone = phone;
            Address = address;
            CreatedAt = DateTime.UtcNow;
            _dogs = new List<Dog>();
        }

        public static Client Create(string fullName, string phone, string address)
        {
            fullName = fullName?.Trim() ?? throw new ArgumentException("Full name cannot be empty.", nameof(fullName));
            phone    = phone?.Trim()    ?? throw new ArgumentException("Phone cannot be empty.", nameof(phone));
            address  = address?.Trim()  ?? throw new ArgumentException("Address cannot be empty.", nameof(address));

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be empty.", nameof(fullName));
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Phone cannot be empty.", nameof(phone));
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address cannot be empty.", nameof(address));

            if (fullName.Length > 200)
                throw new ArgumentException("Full name must be 200 characters or fewer.", nameof(fullName));
            if (phone.Length > 20)
                throw new ArgumentException("Phone must be 20 characters or fewer.", nameof(phone));
            if (address.Length > 300)
                throw new ArgumentException("Address must be 300 characters or fewer.", nameof(address));

            return new Client(fullName, phone, address);
        }
    }
}
