using USFH.DTOs;

namespace USFH.Libs
{
    public class Pagination<T>
    {
        public static PaginationDTO<T> PaginationMethod(int page,int take, int count)
        {
            int pagecount = (int)Math.Ceiling((decimal)count / (decimal)take);
            if (page <= 5 || pagecount<=9)
            {
                if (pagecount <= 9)
                {
                    return new PaginationDTO<T>() { StartPage = 0, PageCount = pagecount, Page = page, EndPage = pagecount-1};
                }
                else
                {
                    return new PaginationDTO<T>() { StartPage = 0, PageCount = pagecount, Page = page, EndPage = 9 };
                }
            }
            else if (page > pagecount - 5)
            {
                return new PaginationDTO<T>() { StartPage = page - 9, PageCount = pagecount, Page = page, EndPage = pagecount - 1 };
            }
            else
            {
                return new PaginationDTO<T>() { StartPage = page - 5, PageCount = pagecount, Page = page, EndPage = page + 4 };
            }
        }
    }
}
