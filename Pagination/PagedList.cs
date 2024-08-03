using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        // valor será definido de acordo com o tamanho da pagina e o total de itens recuperados.
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }




        public PagedList(IEnumerable<T> items, int currentPage, int pageSize, int count)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public PagedList(IEnumerable<T> items, int currentPage, int pageSize, int count, int totalPages)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }
    }
}