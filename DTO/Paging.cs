using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    
    public class Paging
    {
        public Paging() { }

        public Paging(int totalRow, int pageSize, int pageIndex)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalRows = totalRow;
            TotalPages = Math.Ceiling((decimal)totalRow / pageSize);
        }
        public int TotalRows { set; get; }
        public decimal TotalPages { set; get; }
        public int PageSize { set; get; }
        public int PageIndex { set; get; }
    }
}
