using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest.Filter
{
    public interface IFilter<T>
    {
		IEnumerable<T> Validate(IEnumerable<T> elements);
    }
}