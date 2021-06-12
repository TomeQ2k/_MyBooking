using System.Collections.Generic;
using MyBooking.Core.Models;

namespace MyBooking.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> collection, int pageNumber, int pageSize)
           where T : class
           => PagedList<T>.Create(collection, pageNumber, pageSize);
    }
}