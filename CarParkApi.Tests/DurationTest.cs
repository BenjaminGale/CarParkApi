using CarParkApi.Domain;
using Xunit;

namespace CarParkApi.Tests
{
    /*
     * In a real-world solution I'd have unit test coverage for at least all of the domain classes. For this sample I've
     * just decided to test the core date intersection logic which is used to determine which spaces are free for a specified
     * date range.
     */

    public class DurationTest
    {
        [Fact]
        public void DurationBeforeDoesNotIntersect()
        {
            var durationBefore = DateRange.Between(DateTime.Parse("2023-02-21"), DateTime.Parse("2023-02-22"));
            var durationAfter = DateRange.Between(DateTime.Parse("2023-03-01"), DateTime.Parse("2023-03-02"));

            Assert.False(durationBefore.Intersects(durationAfter));
        }

        [Fact]
        public void DurationAfterDoesNotIntersect()
        {
            var durationBefore = DateRange.Between(DateTime.Parse("2023-02-21"), DateTime.Parse("2023-02-22"));
            var durationAfter = DateRange.Between(DateTime.Parse("2023-03-01"), DateTime.Parse("2023-03-02"));

            Assert.False(durationAfter.Intersects(durationBefore));
        }

        [Fact]
        public void DurationBetweenDoesIntersect()
        {
            var duration = DateRange.Between(DateTime.Parse("2023-02-01"), DateTime.Parse("2023-02-10"));
            var durationbetween = DateRange.Between(DateTime.Parse("2023-02-05"), DateTime.Parse("2023-02-07"));

            Assert.True(durationbetween.Intersects(duration));
        }

        [Fact]
        public void DurationIntersectsItself()
        {
            var duration = DateRange.Between(DateTime.Parse("2023-02-01"), DateTime.Parse("2023-02-10"));

            Assert.True(duration.Intersects(duration));
        }

        [Fact]
        public void OverlappingBeforeDurationDoesIntersect()
        {
            var durationBefore = DateRange.Between(DateTime.Parse("2023-02-01"), DateTime.Parse("2023-02-10"));
            var duration = DateRange.Between(DateTime.Parse("2023-02-10"), DateTime.Parse("2023-02-12"));

            Assert.True(durationBefore.Intersects(duration));
        }

        [Fact]
        public void OverlappingAfterDurationDoesIntersect()
        {
            var durationAfter = DateRange.Between(DateTime.Parse("2023-02-12"), DateTime.Parse("2023-02-23"));
            var duration = DateRange.Between(DateTime.Parse("2023-02-10"), DateTime.Parse("2023-02-12"));

            Assert.True(durationAfter.Intersects(duration));
        }
    }
}