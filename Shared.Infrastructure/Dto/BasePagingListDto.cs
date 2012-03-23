using Shared.Infrastructure.Navigation.Dto;

namespace Shared.Infrastructure.Dto
{
    public abstract class BasePagingListDto
    {
        protected BasePagingListDto(PagingInfo paging)
        {
            Paging = paging;
        }

        public PagingInfo Paging { get; private set; }

    }
}