#region

using System;
using Shared.Infrastructure.Navigation.Dto;

#endregion

namespace Shared.Infrastructure.Navigation.Helpers
{
    public static class PagingExtensions
    {
        public static void AdjustForCountOf(this PagingInfo pagingInfo, int totalListCount)
        {
            var currentPage = pagingInfo.CurrentPage;
            var pageSize = pagingInfo.ItemsPerPage;
            if (currentPage < 1) currentPage = 1;
            if (pageSize < 1) pageSize = 100;
            if (pageSize > totalListCount) pageSize = totalListCount;
            var totalPageCount = totalListCount <= 0 ? 0 : (int)Math.Ceiling((double)totalListCount / pageSize);

            if (currentPage > totalPageCount) currentPage = totalPageCount;

            pagingInfo.CurrentPage = currentPage;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = totalListCount;
            pagingInfo.TotalPages = totalPageCount;
        }
    }
}