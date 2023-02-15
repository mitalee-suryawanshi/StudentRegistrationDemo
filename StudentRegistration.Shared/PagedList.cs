using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Shared
{
    public class PagedList<T>//here T is generic data type
    { 
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
        public PagedList()
        {
        }
        public PagedList(List<T> items, int currentPage, int totalPage, int pageSize, long totalCount)
        {
            Items = items;
            CurrentPage = currentPage;
            TotalPage = totalPage;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}