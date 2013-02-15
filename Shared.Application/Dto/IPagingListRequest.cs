#region

using Shared.Application.Dto.Navigation;

#endregion

namespace Shared.Application.Dto
{
    public interface IPagingListRequest<out TSortBy>
    {
        PagingInfo Paging { get; }
        bool OrderByDescending { get; set; }
        TSortBy SortBy { get; }
    }
}