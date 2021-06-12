using MyBooking.Core.Params;

namespace MyBooking.Core.Models
{
    public static class FilterParamsContainer<TParams> where TParams : FilterParams, new()
    {
        public static TParams Params { get; private set; }

        public static TParams Store(TParams filterParams, bool updateParams = false)
        {
            if (updateParams)
                Params = filterParams;

            Params.PageNumber = filterParams.PageNumber;

            return Params;
        }

        public static void Clear()
        {
            Params = new TParams();
        }
    }
}