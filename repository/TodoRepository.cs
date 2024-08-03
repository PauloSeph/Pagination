using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pagination.Data;
using Pagination.Models;

namespace Pagination.repository
{
    public class TodoRepository
    {
        
        public DataContext _context;
        public TodoRepository(DataContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> getTodoAsync(int pageNumber, int pageSize){

            IQueryable<Todo> query = _context.Todos.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }
    }
}