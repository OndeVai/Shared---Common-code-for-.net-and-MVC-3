using Shared.Infrastructure.Navigation.Dto;

namespace Shared.Infrastructure.Querying.Dto
{
    public interface IPagingListRequest<out TSortBy>
    {
        PagingInfo Paging { get; }
        bool OrderByDescending { get; set; }
        TSortBy SortBy { get; }
    }
}