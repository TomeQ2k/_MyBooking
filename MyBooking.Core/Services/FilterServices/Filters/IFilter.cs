using System.Collections.Generic;

namespace MyBooking.Core.Services.FilterServices.Filters
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> collection, ISpecification<T> specification);
    }
}