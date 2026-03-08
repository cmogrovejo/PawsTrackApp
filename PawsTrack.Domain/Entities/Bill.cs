namespace PawsTrack.Domain.Entities
{
    public class Bill
    {
        public int      Id            { get; private set; }
        public int      WalkServiceId { get; private set; }
        public decimal  RatePerHour   { get; private set; }
        public decimal  Discount      { get; private set; }
        public decimal  TotalAmount   { get; private set; }
        public DateTime CreatedAt     { get; private set; }

        private Bill() { }

        private Bill(int walkServiceId, decimal ratePerHour, decimal discount, decimal totalAmount)
        {
            WalkServiceId = walkServiceId;
            RatePerHour   = ratePerHour;
            Discount      = discount;
            TotalAmount   = totalAmount;
            CreatedAt     = DateTime.UtcNow;
        }

        public static Bill Create(int walkServiceId, decimal ratePerHour, decimal discount, double durationHours)
        {
            if (ratePerHour < 0)
                throw new ArgumentException("Rate per hour cannot be negative.", nameof(ratePerHour));
            if (discount < 0)
                throw new ArgumentException("Discount cannot be negative.", nameof(discount));

            var total = Math.Max(0m, (decimal)durationHours * ratePerHour - discount);
            return new Bill(walkServiceId, ratePerHour, discount, total);
        }
    }
}
