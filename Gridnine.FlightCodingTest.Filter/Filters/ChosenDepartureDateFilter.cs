using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest.Filter.Filters
{
    /// <summary>
    /// Represents a filter for getting flights dated specified date.
    /// </summary>
    public class ChosenDepartureDateFilter : IFilter<Flight>
    {
        private DateTime date;

        public ChosenDepartureDateFilter(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get => date; 
            set 
            {
                if (date.CompareTo(DateTime.Now) >= 0)
                    throw new Exception("Past date entered.");
                date = value;
            } 
        }
        public IEnumerable<Flight> Validate(IEnumerable<Flight> elements)
        {
            foreach(var item in elements)
            {
                string flightDay = item.Segments[0].DepartureDate.ToString("MMMM dd, yyyy");
                if(flightDay == date.ToString("MMMM dd, yyyy"))
                    yield return item;
            }
        }
    }
}
