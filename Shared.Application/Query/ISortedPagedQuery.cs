#region

using Shared.Application.Dto.Navigation;

#endregion

namespace Shared.Application.Query
{
    public interface ISortedPagedQuery
    {
        PagingInfo Paging { get; }
    }
}