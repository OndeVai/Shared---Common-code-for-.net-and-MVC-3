using Shared.Application.Infrastructure.Navigation.Dto;

namespace Shared.Application.Infrastructure.Querying.Dto
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