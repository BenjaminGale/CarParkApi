namespace CarParkApi.Domain
{
    public class CarPark
    {
        private readonly IEnumerable<ParkingSpace> _spaces;

        public CarPark(IEnumerable<ParkingSpace> spaces) =>
            _spaces = spaces ?? throw new ArgumentNullException();

        public IEnumerable<ParkingSpace> AvailableSpaces(DateRange duration) =>
            _spaces
                .Where(s => s.IsAvailableFor(duration))
                .ToList();
    }
}
