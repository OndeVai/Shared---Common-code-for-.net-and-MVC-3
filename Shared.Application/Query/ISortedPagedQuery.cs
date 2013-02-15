namespace Shared.Application.Query
{
    public interface ISortedPagedQuery
    {
        int PageNumber { get; }
        int PageSize { get; }
        int TotalSize { get; }
    }
}