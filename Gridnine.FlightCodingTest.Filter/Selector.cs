using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest.Filter
{
    /// <summary>
    /// Represents a tool for filtering of the flights.
    /// </summary>
    public class Selector<T>
    {
        private List<IFilter<T>> filters;

        public Selector()
        {
            filters = new List<IFilter<T>>();
        }

        /// <summary>
        /// Adds a filter to the end of the list.
        /// </summary>
        /// <param name="filter"></param>
        public void AddFilter(IFilter<T> filter)
        {
            if (filters.Contains(filter))
            {
                throw new ArgumentException("Filter allready exist.");
            }
            filters.Add(filter);
        }

        /// <summary>
        /// Removes the element at the specified index of the filters list.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveFilter(int index)
        {
            filters.RemoveAt(index);
        }

        /// <summary>
        /// Removes the first occurrence of a specific filter from the filters list.
        /// </summary>
        public void RemoveFilter(IFilter<T> filter)
        {
            filters.Remove(filter);
        }

        /// <summary>
        /// Returns objects matches filters.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<T> Select(IEnumerable<T> source)
        {
            try
            {
                var selection = ApplyFilters(source);
                return selection;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Can't apply some filter.", e);
            }
        }

        private IEnumerable<T> ApplyFilters(IEnumerable<T> source)
        {
            var result = source;
            foreach (var filter in filters)
            {
                result = filter.Validate(result);
            }
            return result;
        }
    }
}
