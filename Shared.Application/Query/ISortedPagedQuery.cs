using Shared.Application.Dto.Navigation;

namespace Shared.Application.Query
{
    public interface ISortedPagedQuery
    {
        PagingInfo Paging { get; }
    }
}