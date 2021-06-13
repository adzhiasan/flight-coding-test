using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest
{
    public static class FlightExtensions
    {
        public static string GetFlightInfo(this Flight flight)
        {
            string info = "Departure Date\t\t --- \tArrival Date\n" +
                "-----------------------------------------------------\n";
            IList<Segment> segments = flight.Segments;
            foreach (var item in segments)
            {
                info += $"{item.DepartureDate}\t --- \t{item.ArrivalDate}\n";
            }

            return info;
        }
    }
}
