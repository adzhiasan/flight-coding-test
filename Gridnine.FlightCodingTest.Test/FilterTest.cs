using System;
using System.Collections.Generic;
using Gridnine.FlightCodingTest.Filter;
using Gridnine.FlightCodingTest.Filter.Filters;
using System.Linq;
using Xunit;

namespace Gridnine.FlightCodingTest.Test
{
    public class FilterTest
    {
        [Fact]
        public void FlightTimeFilterTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            Selector<Flight> selector = new Selector<Flight>();


            selector.AddFilter(new FlightDurationFilter(2));
            var list = selector.Select(flightBuilder.GetFlights().GetValidFlights()).ToList();

            Assert.Single(list);
        }

        [Fact]
        public void TransferExistsFilterTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            Selector<Flight> selector = new Selector<Flight>();

            selector.AddFilter(new TransferExsistFilter());
            var list = selector.Select(flightBuilder.GetFlights().GetValidFlights()).ToList();

            Assert.Single(list);
        }

        [Theory]
        [MemberData(nameof(ArrivalDates))]
        public void ChosenArrivalDateFilterTest(DateTime dateTime, int expected)
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            Selector<Flight> selector = new Selector<Flight>();

            selector.AddFilter(new ChosenDepartureDateFilter(dateTime));
            var list = selector.Select(flightBuilder.GetFlights().GetValidFlights()).ToList();

            Assert.Equal(expected, list.Count);
        }

        [Theory]
        [MemberData(nameof(FilterCombinations))]
        public void FilterCombinationsTest(List<IFilter<Flight>> filters, int expected)
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            Selector<Flight> selector = new Selector<Flight>();

            foreach (var filter in filters)
            {
                selector.AddFilter(filter);
            }

            var list = selector.Select(flightBuilder.GetFlights().GetValidFlights()).ToList();

            Assert.Equal(expected, list.Count);
        }

        public static IEnumerable<object[]> ArrivalDates()
        {
            yield return new object[] { DateTime.Now.AddDays(3), 2 };
            yield return new object[] { DateTime.Now.AddDays(1), 0 };
        }

        public static IEnumerable<object[]> FilterCombinations()
        {
            FlightDurationFilter flightDurationFilter = new FlightDurationFilter(5);
            TransferExsistFilter transferExistsFilter = new TransferExsistFilter();
            ChosenDepartureDateFilter chosenDepartureDateFilter = new ChosenDepartureDateFilter(DateTime.Now.AddDays(3));

            yield return new object[] { new List<IFilter<Flight>> { flightDurationFilter, transferExistsFilter }, 1 };
            yield return new object[] { new List<IFilter<Flight>> { flightDurationFilter, transferExistsFilter, chosenDepartureDateFilter }, 1};
        }
    }
}
