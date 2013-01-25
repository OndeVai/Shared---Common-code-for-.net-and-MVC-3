using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Domain.Repository;
using Shared.Infrastructure.Dto;

namespace Shared.Infrastructure.Query.Impl
{
    public class QueryService<TDtoSummary, TDtoDetail, TDomain, TSortBy, TRepository>
        where TDomain : class
        where TDtoDetail : class
        where TRepository : IEntityRepository<TDomain>
    {

        public QueryService(TRepository repository)
        {
            Repository = repository;
        }

        protected TRepository Repository { get; private set; }

        #region IQueryService<TDto,TSortBy> Members

        public PagedListResponse<TDtoSummary> List(PagingListRequest<TSortBy> listRequest, 
                                                    Func<List<TDomain>, List<TDtoSummary>> mappingExp,
                                                    IQuery<TDomain,TSortBy> query)
        {

            var list = query.Execute(listRequest).ToList();
            var convertedList = mappingExp(list);
            return new PagedListResponse<TDtoSummary>(convertedList, listRequest.Paging);
        }

        public TDtoDetail Find(UidRequest uidFindRequest, Func<TDomain, TDtoDetail> mappingExp)
        {
            var find = Repository.Find(uidFindRequest.Id);
            return find != null ? mappingExp(find) : null;
        }

        #endregion

       
    }
}