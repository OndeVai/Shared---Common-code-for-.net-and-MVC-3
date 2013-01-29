#region

using System;

#endregion

namespace Shared.Infrastructure.Dto.Navigation
{
    public class PagingInfo
    {
        public PagingInfo()
        {
            TotalItems = 0;
            TotalPages = 0;
        }

        public PagingInfo(int currentPage, int itemsPerPage)
            : this()
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalPages { get; private set; }
        public int TotalItems { get; private set; }
        public int? NextPage { get; private set; }
        public int? PrevPage { get; private set; }

        public void BuildActuals(int actualListCount)
        {
            var currentPage = CurrentPage;
            var pageSize = ItemsPerPage;
            if (currentPage < 1) currentPage = 1;
            if (pageSize < 1) pageSize = 100;
            if (pageSize > actualListCount) pageSize = actualListCount;
            var totalPageCount = actualListCount <= 0 ? 0 : (int) Math.Ceiling((double) actualListCount/pageSize);

            if (currentPage >= totalPageCount)
            {
                NextPage = null;
                currentPage = totalPageCount;
            }
            else
                NextPage = currentPage + 1;

            PrevPage = currentPage > 1 ? (int?) (currentPage - 1) : null;

            CurrentPage = currentPage;
            ItemsPerPage = pageSize;
            TotalItems = actualListCount;
            TotalPages = totalPageCount;
        }
    }
}