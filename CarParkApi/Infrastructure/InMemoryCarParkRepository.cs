using CarParkApi.Domain;

namespace CarParkApi.Infrastructure
{
    /*
     * This simulates a simple database to keep the example simple. In a real-world solution
     * the repository implementation would connect to a database or call another API.
     */

    public class InMemoryCarParkRepository : ICarParkRepository
    {
        private readonly IList<ParkingSpace> Spaces = new List<ParkingSpace>
        {
            new ParkingSpace(Guid.NewGuid(), "Space 1", new List<Booking>
            {
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-05"), DateTime.Parse("2023-03-22")))
            }),

            new ParkingSpace(Guid.NewGuid(), "Space 2", new List<Booking>
            {
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-01"), DateTime.Parse("2023-03-01"))),
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-04"), DateTime.Parse("2023-03-09"))),
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-10"), DateTime.Parse("2023-03-12")))
            }),

            new ParkingSpace(Guid.NewGuid(), "Space 3", Enumerable.Empty<Booking>()),

            new ParkingSpace(Guid.NewGuid(), "Space 4", new List<Booking>
            {
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-04"), DateTime.Parse("2023-03-05"))),
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-08"), DateTime.Parse("2023-03-17"))),
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-25"), DateTime.Parse("2023-03-28"))),

            }),

            new ParkingSpace(Guid.NewGuid(), "Space 5", Enumerable.Empty<Booking>()),
            new ParkingSpace(Guid.NewGuid(), "Space 6", Enumerable.Empty<Booking>()),
            new ParkingSpace(Guid.NewGuid(), "Space 7", Enumerable.Empty<Booking>()),

            new ParkingSpace(Guid.NewGuid(), "Space 8", new List<Booking>
            {
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-01"), DateTime.Parse("2023-03-03"))),
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-04"), DateTime.Parse("2023-03-08"))),
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-09"), DateTime.Parse("2023-03-09"))),
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-10"), DateTime.Parse("2023-03-13"))),
                new Booking(Guid.NewGuid(), DateRange.Between(DateTime.Parse("2023-03-28"), DateTime.Parse("2023-03-29"))),
            }),

            new ParkingSpace(Guid.NewGuid(), "Space 9", Enumerable.Empty<Booking>()),
            new ParkingSpace(Guid.NewGuid(), "Space 10", Enumerable.Empty<Booking>()),
        };

        public Task<CarPark> Get() =>
            Task.FromResult(new CarPark(Spaces.ToList()));
    }
}
