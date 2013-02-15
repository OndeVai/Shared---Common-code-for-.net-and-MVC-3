#region

using System.Collections.Generic;
using Shared.Application.Dto.Navigation;

#endregion

namespace Shared.Application.Dto
{
    public class PagedListResponse<TSummary> : BasePagingList
    {
        public PagedListResponse(List<TSummary> list, PagingInfo paging)
            : base(paging)
        {
            List = list;
        }

        public List<TSummary> List { get; private set; }
    }
}