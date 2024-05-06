using System.Drawing.Printing;

namespace PostMidProject.Models
{
    public class Pager
    {
        public int TotalItems { get; set; }
        public int CurrentPage {  get; set; }
        public int TotalPages { get; set; }
        public int PageSize {  get; set; }
        public int StartPage {  get; set; } 
        public int EndPage { get; set; }
        public Pager()
        {

        }

        public Pager(int totalItems, int page, int pageSize)
        {
           
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;
            if(startPage <= 0)
            {
                endPage = endPage-(startPage - 1);
                startPage = 1;
            }

            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage>10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalPages;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            StartPage = startPage;
            EndPage = endPage;

        }
    }

    
}
