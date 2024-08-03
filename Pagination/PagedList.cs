using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage {get;set;}
        // valor será definido de acordo com o tamanho da pagina e o total de itens recuperados.
        public int TotalPages {get; set;} 
        public int PageSize {get; set;}
        public int TotalCount {get;set;}


        public PagedList(IEnumerable<T> items, int pageNumber, int pageSize, int count){

            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double) pageSize);
            PageSize = pageSize;
            TotalCount = count;

            AddRange(items);
        }

    }
}