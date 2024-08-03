using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagination.DTOs;
using Pagination.Models;
using Pagination.Pagination;
using Pagination.repository;

namespace Pagination.Services
{
    public class TodoService
    {
        private TodoRepository _todoRepository;

        public TodoService(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<PagedList<Todo>> SelectTodosAsync(int pageNumber, int pageSize){

            // valida algo...
            PagedList<Todo> page = await _todoRepository.getTodoAsync(pageNumber, pageSize);  

            // faz mapeamento...      
            return page;        
        }
    }
}