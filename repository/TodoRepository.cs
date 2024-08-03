using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pagination.Data;
using Pagination.Models;
using Pagination.Pagination;

namespace Pagination.repository
{
    public class TodoRepository
    {
        
        public DataContext _context;
        public TodoRepository(DataContext context) {
            _context = context;
        }

        public async Task<PagedList<Todo>> getTodoAsync(int pageNumber, int pageSize){

            IQueryable<Todo> query = _context.Todos.AsQueryable();

            PagedList<Todo> List = await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
            return List;
        }
    }
}