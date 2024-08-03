using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pagination.Pagination;

namespace Pagination.Data
{
    public class PaginationHelper
    {
        public static async Task<PagedList<T>> CreateAsync<T> 
        (IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            PagedList<T> List = new PagedList<T>(items, pageNumber, pageSize, count);

            return List;
        }
    }
}