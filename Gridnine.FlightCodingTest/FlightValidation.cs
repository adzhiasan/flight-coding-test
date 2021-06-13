using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest
{
    public static class FlightValidation
    {
        /// <summary>
        /// Returns valid (actual) flights.
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public static IEnumerable<Flight> GetValidFlights(this IEnumerable<Flight> flights)
        {
            bool isValid;

            foreach (var item in flights)
            {
                isValid = !DepartureTillNow(item) && !DepartureAfterAriving(item) && !GroundTimeMoreThanTwoHours(item);
                if (isValid)
                    yield return item;
            }
        }

        private static bool DepartureTillNow(Flight flight)
        {
            if (flight.Segments[0].DepartureDate.CompareTo(DateTime.Now) < 0)
                return true;
            return false;
        }

        private static bool DepartureAfterAriving(Flight flight)
        {
            var segments = flight.Segments;
            foreach (var item in segments)
            {
                if (item.ArrivalDate.CompareTo(item.DepartureDate) < 0)
                    return true;
            }
            return false;
        }

        private static bool GroundTimeMoreThanTwoHours(Flight flight)
        {
            var segments = flight.Segments;
            int segmentsNumber = flight.Segments.Count;

            for (int i = 1; i < segmentsNumber; i++)
            {
                TimeSpan groundTime = segments[i].DepartureDate - segments[i - 1].ArrivalDate;
                if (groundTime.Hours >= 2)
                    return true;
            }

            return false;
        }
    }
}

