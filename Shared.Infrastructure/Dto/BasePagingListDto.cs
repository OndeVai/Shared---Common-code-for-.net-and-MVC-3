#region

using Shared.Infrastructure.Navigation.Dto;

#endregion

namespace Shared.Infrastructure.Dto
{
    public abstract class BasePagingListDto
    {
        protected BasePagingListDto(int currentPage, int itemsPerPage) : this(new PagingInfo(currentPage, itemsPerPage))
        {
        }

        protected BasePagingListDto(PagingInfo paging)
        {
            Paging = paging;
        }

        public PagingInfo Paging { get; protected set; }
    }
}