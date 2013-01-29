#region

using Shared.Infrastructure.Dto;

#endregion

namespace Shared.Infrastructure.Query
{
    public interface IQueryResultsConverter<TDtoSummary, out TDtoDetail, in TDomain, TSortBy> where TDtoDetail : class
                                                                                              where TDomain : class
    {
        PagedListResponse<TDtoSummary> ToList(PagingListRequest<TSortBy> listRequest,
                                              IQuery<TDomain, TSortBy> query);

        TDtoDetail ToDetail(UidRequest uidFindRequest);
    }
}