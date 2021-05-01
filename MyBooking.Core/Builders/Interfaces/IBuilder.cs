namespace MyBooking.Core.Builders.Interfaces
{
    public interface IBuilder<T> where T : class, new()
    {
        T Build();
    }
}