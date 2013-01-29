#region

using Shared.Infrastructure.Dto;

#endregion

namespace Shared.Infrastructure.Query
{
    public interface IApplicationQueryService<TSummary, out TDetail, TSortBy>
    {
        PagedListResponse<TSummary> List(PagingListRequest<TSortBy> listRequest);
        TDetail Find(UidRequest promotionFindRequest);
    }
}