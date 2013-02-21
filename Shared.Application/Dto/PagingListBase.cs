#region

using Shared.Application.Dto.Navigation;

#endregion

namespace Shared.Application.Dto
{
    public abstract class PagingListBase
    {
        protected PagingListBase(int currentPage, int itemsPerPage) : this(new PagingInfo(currentPage, itemsPerPage))
        {
        }

        protected PagingListBase(PagingInfo paging)
        {
            Paging = paging;
        }

        public PagingInfo Paging { get; protected set; }
    }
}