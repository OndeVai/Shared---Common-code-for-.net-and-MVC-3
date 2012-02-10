using Shared.Application.Infrastructure.Navigation.Dto;

namespace Shared.Application.Infrastructure.Querying.Dto
{
    public interface IPagingListRequest<out TSortBy>
    {
        PagingInfo Paging { get; }
        bool OrderByDescending { get; set; }
        TSortBy SortBy { get; }
    }
}