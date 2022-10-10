using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USFH.DTOs
{
    public class PaginationDTO<T>
    {
        public int StartPage { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int EndPage { get; set; }
        public T? Object { get; set; }
    }
}
