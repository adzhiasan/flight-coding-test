using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest.Filter.Filters
{
    /// <summary>
    /// Represents a filter for getting flights which lasts specified hours.
    /// </summary>
    public class FlightDurationFilter : IFilter<Flight>
    {
        private uint hours;
        public uint Hours
        {
            get => hours;
            set
            {
                hours = value;
            }
        }

        public FlightDurationFilter(uint _hours)
        {
            Hours = _hours;
        }
        public IEnumerable<Flight> Validate(IEnumerable<Flight> elements)
        {

            foreach (var item in elements)
            {
                double flightTime = (item.Segments.Last().ArrivalDate - item.Segments.First().DepartureDate).Hours;
                if (flightTime == hours)
                {
                    yield return item;
                }
            }
        }
    }
}
