#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shared.Linq;

#endregion

namespace Shared.Domain.Query.Impl
{
    public abstract class SortedPagedQuery<TEntity> : ISortedPagedQuery
    {
        private Expression<Func<TEntity, bool>> _curExpression;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalSize { get; protected set; }

        public Expression<Func<TEntity, bool>> AsExpression()
        {
            return _curExpression;
        }

        public Expression<Func<TEntity, bool>> AndAlso(
            SortedPagedQuery<TEntity> otherSortedPagedQuery)
        {
            return AsExpression().AndAlso(otherSortedPagedQuery.AsExpression());
        }

        public Expression<Func<TEntity, bool>> OrElse(
            SortedPagedQuery<TEntity> otherSortedPagedQuery)
        {
            return AsExpression().OrElse(otherSortedPagedQuery.AsExpression());
        }

        protected void AddCriteria(Expression<Func<TEntity, bool>> nextExpression)
        {
            _curExpression = (_curExpression == null)
                                 ? nextExpression
                                 : _curExpression.AndAlso(nextExpression);
        }

        public List<TEntity> Execute(IQueryable<TEntity> baseQuery)
        {
            BuildCriteria();
            baseQuery = baseQuery.Where(AsExpression());
            TotalSize = baseQuery.Count();
            AdjustPaging();
            return Sort(baseQuery).Page(PageNumber, PageSize).ToList();
        }


        protected abstract IQueryable<TEntity> Sort(IQueryable<TEntity> baseQuery);
        protected abstract void BuildCriteria();
        protected abstract void Validate();

        protected void AdjustPaging()
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