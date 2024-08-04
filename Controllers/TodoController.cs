using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pagination.DTOs;
using Pagination.Extensions;
using Pagination.Services;

namespace Pagination.Controllers
{
    [ApiController]
    [Route("v2/todo")]
    public class TodoController : ControllerBase
    {
        public TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParams paginationParams)
        {
            var Todos = await _todoService
            .GetTodosWithPagination(paginationParams.PageNumber, paginationParams.PageSize);


            Response.AddPaginationHeader(
                new PaginationHeader(Todos.CurrentPage, Todos.PageSize, Todos.TotalCount, Todos.TotalPages)
                );

            // Aqui eu poderia retornar o objeto paging que contém os dados e as informacoes da paginacao.
            // Mas e nao poderia passar no Header como foi feito, porém ai teria que apenas retornar os items na resposta 
            // da requisicao BODY.  

            return Ok(Todos.Items);
        }
    }
}