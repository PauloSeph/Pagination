using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pagination.Pagination
{
    public class ExtensionPaging
    {

        // encapsulando a query para obter a quantidade e realizar a paginacao, ou seja, skip e take.
        public async static Task<Paging<T>> PagingTest<T>(IQueryable<T> source, int currentPage, int pageSize) where T : class
        {
            var count = await source.CountAsync();
            var items = await source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            Paging<T> resultPage = new Paging<T>(currentPage, count, pageSize, items); // retornando o objeto com os registros e as informacoes sobre essa paginacao.

            return resultPage;

        }
    }
}