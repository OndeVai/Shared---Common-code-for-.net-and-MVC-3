using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shared.Domain.Repository;
using Shared.Infrastructure.Dto;

namespace Shared.Infrastructure.Service.Impl
{
    public class QueryService<TDtoSummary, TDtoDetail, TDomain, TSortBy, TRepository>
        where TDomain : class
        where TDtoDetail : class
        where TRepository : IEntityRepository<TDomain>
    {
        private readonly IPagedQueryGenerator<TDomain, TSortBy> _pagedQueryGenerator;

        public QueryService(TRepository repository, IPagedQueryGenerator<TDomain, TSortBy> pagedQueryGenerator)
        {
            Repository = repository;
            _pagedQueryGenerator = pagedQueryGenerator;
        }

        protected TRepository Repository { get; private set; }

        #region IQueryService<TDto,TSortBy> Members

        public PagingListResponse<TDtoSummary> List(PagingListRequest<TSortBy> listRequest, Func<List<TDomain>, List<TDtoSummary>> mappingExp,
                                                    Expression<Func<TDomain, bool>> filterExpression = null)
        {
            var query = Repository.GetAll();
            if (filterExpression != null) query = query.Where(filterExpression);
            var list = _pagedQueryGenerator.CreateQueryFor(query, listRequest).ToList();
            var convertedList = mappingExp(list);
            return new PagingListResponse<TDtoSummary>(convertedList, listRequest.Paging);
        }

        public TDtoDetail Find(UidRequest uidFindRequest, Func<TDomain, TDtoDetail> mappingExp)
        {
            var find = Repository.Find(uidFindRequest.Id);
            return find != null ? mappingExp(find) : null;
        }

        #endregion

       
    }
}