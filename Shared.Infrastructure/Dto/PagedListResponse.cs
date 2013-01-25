using System.Collections.Generic;
using Shared.Infrastructure.Navigation.Dto;

namespace Shared.Infrastructure.Dto
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