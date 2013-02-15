#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shared.Linq;

#endregion

namespace Shared.Application.Query
{
    public abstract class SortedPagedQuery<TSource, TResult> : ISortedPagedQuery, IQuery<TSource, TResult>
    {
        private Expression<Func<TSource, bool>> _curExpression;

        public IEnumerable<TResult> Execute(IQueryable<TSource> baseQuery)
        {
            Validate();
            BuildCriteria();
            baseQuery = baseQuery.Where(AsExpression());
            TotalSize = baseQuery.Count();
            AdjustPaging();
            return Sort(baseQuery).Page(PageNumber, PageSize).AsEnumerable();
        }

        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalSize { get; private set; }

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
        protected abstract void BuildCriteria();

        private void AdjustPaging()
        {
            var actualQueryCount = TotalSize;
            var currentPage = PageNumber;
            var pageSize = PageSize;
            if (currentPage < 1) currentPage = 1;
            if (pageSize < 1) pageSize = 100;
            if (pageSize > actualQueryCount) pageSize = actualQueryCount;
            var totalPageCount = actualQueryCount <= 0 ? 0 : (int) Math.Ceiling((double) actualQueryCount/pageSize);

            if (currentPage >= totalPageCount)
                currentPage = totalPageCount;

            PageNumber = currentPage;
            PageSize = pageSize;
        }
    }
}