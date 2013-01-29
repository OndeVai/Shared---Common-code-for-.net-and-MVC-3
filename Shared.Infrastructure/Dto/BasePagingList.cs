#region

using Shared.Infrastructure.Dto.Navigation;

#endregion

namespace Shared.Infrastructure.Dto
{
    public abstract class BasePagingList
    {
        protected BasePagingList(int currentPage, int itemsPerPage) : this(new PagingInfo(currentPage, itemsPerPage))
        {
        }

        protected BasePagingList(PagingInfo paging)
        {
            Paging = paging;
        }

        public PagingInfo Paging { get; protected set; }
    }
}