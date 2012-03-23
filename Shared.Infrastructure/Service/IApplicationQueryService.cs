using Shared.Infrastructure.Dto;

namespace Shared.Infrastructure.Service
{
    public interface IApplicationQueryService<TSummary, out TDetail, TSortBy>
    {
        PagingListResponse<TSummary> List(PagingListRequest<TSortBy> listRequest);
        TDetail Find(UidRequest promotionFindRequest);
    }
}