using System;
using System.Linq;

namespace Gridnine.FlightCodingTest.Main
{
    class Program
    {
        static void Main(string[] args)
        {

            FlightBuilder flightBuilder = new FlightBuilder();
            var flights = flightBuilder.GetFlights().GetValidFlights().ToList();
            foreach (var flight in flights)
            {
                Console.WriteLine(flight.GetFlightInfo());
            }
        }
    }
}
