using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace Pagination.Pagination
{
    public class Paging<T> // método servirá apenas para 
    {
        public int CurrentPage { get; set; }  // pagina atual
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        private int _TotalPages;
        public int TotalPages
        {
            get { return _TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize); }
            // set { _TotalPages = value; }
        }

        public Paging(int currentPage, int totalCount, int pageSize, List<T> items)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = totalCount;
            Items = items ?? new List<T>();
        }
    }
}