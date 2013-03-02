#region

using System;
using System.Linq;
using System.Linq.Expressions;
using Shared.Application.Dto.Navigation;
using Shared.Linq;

#endregion

namespace Shared.Application.Query
{
    public abstract class SortedPagedQuery<TSource, TResult> : ISortedPagedQuery, IQuery<TSource, TResult>
    {
        private Expression<Func<TSource, bool>> _curExpression;

        protected SortedPagedQuery()
        {
        }

        public SortedPagedQuery(PagingInfo paging)
        {
            Paging = paging;
        }

        public IQueryable<TResult> Execute(IQueryable<TSource> baseQuery)
        {
            Validate();
            BuildWhere();
            var asExpression = AsExpression();

            if (asExpression != null)
                baseQuery = baseQuery.Where(asExpression);

            var queryCount = baseQuery.Count();
            AdjustPaging(queryCount);
            return Sort(baseQuery).Page(Paging.CurrentPage, Paging.ItemsPerPage);
        }

        public PagingInfo Paging { get; private set; }

        private Expression<Func<TSource, bool>> AsExpression()
        {
            return _curExpression;
        }

        protected void AddCriteria(Expression<Func<TSource, bool>> nextExpression)
        {
            _curExpression = (_curExpression == null)
                                 ? nextExpression
                                 : _curExpression.AndAlso(nextExpression);
        }

        protected abstract void Validate();
        protected abstract IQueryable<TResult> Sort(IQueryable<TSource> baseQuery);
        protected abstract void BuildWhere();

        private void AdjustPaging(int queryCount)
        {
            Paging.BuildActuals(queryCount);
        }
    }
}