using PawsTrack.Domain.Enums;

namespace PawsTrack.Domain.Entities
{
    public class WalkService
    {
        public int        Id        { get; private set; }
        public int        ClientId  { get; private set; }
        public int        DogId     { get; private set; }
        public DateTime   StartTime { get; private set; }
        public DateTime   EndTime   { get; private set; }
        public WalkStatus Status    { get; private set; }
        public DateTime   CreatedAt { get; private set; }

        private WalkService() { }

        private WalkService(int clientId, int dogId, DateTime startTime, DateTime endTime)
        {
            ClientId  = clientId;
            DogId     = dogId;
            StartTime = startTime;
            EndTime   = endTime;
            Status    = WalkStatus.Created;
            CreatedAt = DateTime.Now;
        }

        public static WalkService Create(int clientId, int dogId, DateTime startTime, DateTime endTime)
        {
            if (clientId <= 0)
                throw new ArgumentException("ClientId must be greater than zero.", nameof(clientId));
            if (dogId <= 0)
                throw new ArgumentException("DogId must be greater than zero.", nameof(dogId));
            if (startTime <= DateTime.Now)
                throw new ArgumentException("Start time must be in the future.", nameof(startTime));
            if (endTime <= startTime)
                throw new ArgumentException("End time must be after start time.", nameof(endTime));

            return new WalkService(clientId, dogId, startTime, endTime);
        }

        public void Reschedule(DateTime newStart, DateTime newEnd)
        {
            if (Status != WalkStatus.Created)
                throw new InvalidOperationException("Only services in 'Created' status can be rescheduled.");
            if (newStart <= DateTime.Now)
                throw new ArgumentException("Start time must be in the future.", nameof(newStart));
            if (newEnd <= newStart)
                throw new ArgumentException("End time must be after start time.", nameof(newEnd));

            StartTime = newStart;
            EndTime   = newEnd;
        }
    }
}
