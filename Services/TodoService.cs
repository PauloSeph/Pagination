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

        public async Task<Paging<Todo>> GetTodosWithPagination(int pageNumber, int pageSize){

            // valida algo...
            Paging<Todo> page = await _todoRepository.getTodoAsync(pageNumber, pageSize);  

            Console.WriteLine(page);

            // faz mapeamento...   
            // no caso se precisar do mapeamento, seria necessario converter a nossa entidade para a DTO, pois
            // o que nós queremos retornar é a DTO.

            return page;        
        }
    }
}