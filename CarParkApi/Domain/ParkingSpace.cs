
namespace CarParkApi.Domain
{
    public class ParkingSpace
    {
        private readonly IEnumerable<Booking> _bookings;

        public ParkingSpace(Guid id, string name, IEnumerable<Booking> bookings)
        {
            if (id == Guid.Empty) throw new ArgumentException();
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
            if (bookings is null) throw new ArgumentNullException();

            Id = id;
            Name = name;
            _bookings = bookings;
        }

        public Guid Id { get; }

        public string Name { get; }

        public bool IsAvailableFor(DateRange duration) =>
            !_bookings.Any(booking => booking.Duration.Intersects(duration));
    }
}
