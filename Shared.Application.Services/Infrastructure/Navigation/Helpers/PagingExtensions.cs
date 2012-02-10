#region

using System;
using Shared.Application.Infrastructure.Navigation.Dto;

#endregion

namespace Shared.Application.Infrastructure.Navigation.Helpers
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
            var totalPageCount = (int)Math.Ceiling((double)totalListCount / pageSize);
            if (currentPage > totalPageCount) currentPage = totalPageCount;

            pagingInfo = new PagingInfo { CurrentPage = currentPage, ItemsPerPage = pageSize, TotalItems = totalListCount, TotalPages = totalPageCount };
        }
    }
}