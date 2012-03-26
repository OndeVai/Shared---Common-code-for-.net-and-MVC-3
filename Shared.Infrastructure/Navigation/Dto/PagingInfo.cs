namespace Shared.Infrastructure.Navigation.Dto
{
    public class PagingInfo
    {
        public PagingInfo()
        {
            
        }

        public PagingInfo(int currentPage, int itemsPerPage)
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