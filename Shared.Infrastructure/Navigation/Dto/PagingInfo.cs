namespace Shared.Infrastructure.Navigation.Dto
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
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}