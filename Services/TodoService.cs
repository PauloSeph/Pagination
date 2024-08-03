using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pagination.DTOs;
using Pagination.Pagination;
using Pagination.repository;

namespace Pagination.Services
{
    public class TodoService
    {

        public TodoRepository _todoRepository;

        public TodoService(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }



        public async Task<PagedList<TodoDto>> SelectTodosAsync(int pageNumber, int pageSize){
            var dotos = await _todoRepository.getTodoAsync(pageNumber, pageSize)

        }
    }
}