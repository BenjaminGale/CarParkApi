namespace CarParkApi.Domain
{
    public class Booking
    {
        public Booking(Guid id, DateRange duration)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (duration is null) throw new ArgumentNullException(nameof(duration));

            Id = id;
            Duration = duration;
        }

        public Guid Id { get; }

        public DateRange Duration { get; }
    }
}
