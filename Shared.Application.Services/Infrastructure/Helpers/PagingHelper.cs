#region

using System;
using Shared.Application.Services.Dto;

#endregion

namespace Shared.Application.Services.Infrastructure.Helpers
{
    public static class PagingExtensions
    {
        public static PagingInfo AdjustForCountOf(this PagingInfo pagingInfo, int totalListCount)
        {
            var currentPage = pagingInfo.CurrentPage;
            var pageSize = pagingInfo.ItemsPerPage;
            if (currentPage < 1) currentPage = 1;
            if (pageSize < 1) pageSize = 100;
            if (pageSize > totalListCount) pageSize = totalListCount;
            var totalPageCount = (int)Math.Ceiling((double)totalListCount / pageSize);
            if (currentPage > totalPageCount) currentPage = totalPageCount;

            return new PagingInfo { CurrentPage = currentPage, ItemsPerPage = pageSize, TotalItems = totalListCount, TotalPages = totalPageCount };
        }
    }
}