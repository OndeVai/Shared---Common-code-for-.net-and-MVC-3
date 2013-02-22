#region

using System;

#endregion

namespace Shared.Application.Dto.Navigation
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
            if (currentPage < 1)
                throw new ArgumentException("current page cannot be < 1", "currentPage");

            CurrentPage = currentPage < 1 ? 1 : currentPage;
            ItemsPerPage = itemsPerPage < 1 ? 1 : itemsPerPage;
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
        
            var isEmptyList = actualListCount <= 0;

            var totalPageCount = isEmptyList ? 0 : (int)Math.Ceiling((double)actualListCount / actualListCount);

            if (currentPage >= totalPageCount)
            {
                NextPage = null;
                currentPage = isEmptyList ? 1 : totalPageCount;
            }
            else
                NextPage = currentPage + 1;

            PrevPage = currentPage > 1 ? (int?)(currentPage - 1) : null;

            CurrentPage = currentPage;
            TotalItems = actualListCount;
            TotalPages = totalPageCount;
        }
    }
}