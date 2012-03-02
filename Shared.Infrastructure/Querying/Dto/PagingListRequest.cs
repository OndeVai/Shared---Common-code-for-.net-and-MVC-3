using Shared.Infrastructure.Navigation.Dto;

namespace Shared.Infrastructure.Querying.Dto
{
    public class PagingListRequest<TSortBy> : BasePagingListDto, IPagingListRequest<TSortBy>
    {
        public PagingListRequest(TSortBy sortBy, PagingInfo paging) : base(paging)
        {
            SortBy = sortBy;
        }

        public bool OrderByDescending { get; set; }
        public TSortBy SortBy { get; private set; }
    }
}