using System.Collections.Generic;
using Shared.Infrastructure.Navigation.Dto;

namespace Shared.Infrastructure.Querying.Dto
{
    public class PagingListResponse<TSummary> : BasePagingListDto
    {
        public PagingListResponse(List<TSummary> list, PagingInfo paging)
            : base(paging)
        {
            List = list;
        }

        public List<TSummary> List { get; private set; }
    }
}