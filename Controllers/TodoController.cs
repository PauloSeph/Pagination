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
            .SelectTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(
                new PaginationHeader(Todos.CurrentPage, Todos.PageSize, Todos.TotalCount, Todos.TotalPages)
                );

            return Ok(Todos);
        }
    }
}