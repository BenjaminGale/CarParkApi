namespace CarParkApi.Domain
{
    public interface ICarParkRepository
    {
        /*
         * Task isn't really required for this example but a real-world solution would require
         * async because it would likely be connecting to a database or another API.
         */
        Task<CarPark> Get();
    }
}
