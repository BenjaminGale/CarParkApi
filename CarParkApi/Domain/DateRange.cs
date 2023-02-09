namespace CarParkApi.Domain
{
    public class DateRange
    {
        public static DateRange Between(DateTime from, DateTime to) => new(from, to);

        public static bool CanBeCreatedFrom(DateTime from, DateTime to) => to >= from;

        private DateRange(DateTime from, DateTime to)
        {
            if (!CanBeCreatedFrom(from, to)) throw new ArgumentOutOfRangeException();

            From = from;
            To = to;
        }

        public DateTime From { get; }

        public DateTime To { get; }

        public bool Intersects(DateRange other) =>
            To.Date >= other.From.Date && From.Date <= other.To.Date;
    }
}
