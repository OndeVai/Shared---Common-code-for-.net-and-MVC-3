using Shared.Infrastructure.Dto;

namespace Shared.Infrastructure.Query
{
    public interface IApplicationQueryService<TSummary, out TDetail, TSortBy>
    {
        PagedListResponse<TSummary> List(PagingListRequest<TSortBy> listRequest);
        TDetail Find(UidRequest promotionFindRequest);
    }
}