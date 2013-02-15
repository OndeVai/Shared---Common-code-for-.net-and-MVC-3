#region

using Shared.Application.Dto.Navigation;

#endregion

namespace Shared.Application.Dto
{
    public class PagingListRequest<TSortBy> : BasePagingList, IPagingListRequest<TSortBy>
    {
        public PagingListRequest(TSortBy sortBy, int currentPage, int itemsPerPage)
            : this(sortBy, new PagingInfo(currentPage, itemsPerPage))
        {
        }

        public PagingListRequest(TSortBy sortBy, PagingInfo paging)
            : base(paging)
        {
            SortBy = sortBy;
        }

        #region IPagingListRequest<TSortBy> Members

        public bool OrderByDescending { get; set; }
        public TSortBy SortBy { get; private set; }

        #endregion
    }
}