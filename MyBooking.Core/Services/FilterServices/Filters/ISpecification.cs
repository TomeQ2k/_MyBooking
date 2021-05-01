namespace MyBooking.Core.Services.FilterServices.Filters
{
    public interface ISpecification<T>
    {
        bool Predicate(T item);

        bool Precondition();
    }
}