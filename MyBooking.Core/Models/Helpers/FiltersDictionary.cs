using System.Collections.Generic;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Core.Models.Helpers
{
    public class FiltersDictionary<T> : Dictionary<ISpecification<T>, IFilter<T>>
    {
        public IEnumerable<T> RunFilters(IEnumerable<T> collection)
        {
            foreach (var specification in this.Keys)
                collection = this[specification].Filter(collection, specification);

            return collection;
        }
    }
}