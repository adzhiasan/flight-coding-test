using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest.Filter.Filters
{
    /// <summary>
    /// Represents a filter for getting flights with transfers. 
    /// </summary>
    public class TransferExsistFilter : IFilter<Flight>
    {
        public TransferExsistFilter()
        {

        } 
        public IEnumerable<Flight> Validate(IEnumerable<Flight> elements)
        {
            foreach (var item in elements)
            {
                if(item.Segments.Count > 1)
                    yield return item;
            };
        }
    }
}
