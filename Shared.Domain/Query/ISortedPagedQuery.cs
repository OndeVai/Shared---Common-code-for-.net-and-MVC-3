namespace Shared.Domain.Query
{
    public interface ISortedPagedQuery
    {
        int PageNumber { get; }
        int PageSize { get; }
        int Count { get; }
    }
}