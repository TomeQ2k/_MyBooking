namespace MyBooking.Core.Params
{
    public abstract class FilterParams
    {
        protected const int MaxPageSize = int.MaxValue;
        protected const int MinPageNumber = 1;

        protected int pageNumber = MinPageNumber;
        public int PageNumber
        {
            get => pageNumber;
            set => pageNumber = (value < MinPageNumber) ? MinPageNumber : value;
        }

        protected int pageSize = 2;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public bool FilterEnabled { get; private set; }

        public TParams EnableFiltering<TParams>() where TParams : FilterParams, new()
        {
            FilterEnabled = true;
            return this as TParams;
        }
    }
}