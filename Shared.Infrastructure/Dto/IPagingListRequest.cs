#region

using Shared.Infrastructure.Dto.Navigation;

#endregion

namespace Shared.Infrastructure.Dto
{
    public interface IPagingListRequest<out TSortBy>
    {
        PagingInfo Paging { get; }
        bool OrderByDescending { get; set; }
        TSortBy SortBy { get; }
    }
}