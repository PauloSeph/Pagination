using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagination.Data;
using Pagination.Models;

namespace Pagination.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class Paginacao : ControllerBase
    {

        [HttpGet("load")] // esse middileware só será usado para carregar dados de exemplo
        public async Task<IActionResult> LoadAsync([FromServices] DataContext context) {

            for (int i = 0; i < 1348; i++)
            {   
                var todo = new Todo() {
                    Id = i + 1,
                    Done = false,
                    CreatedAt = DateTime.Now,
                    Title = $"Tarefa {i}"
                };

                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();
            }

            return Ok("Carregado os dados ficticios");
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAsync(
            [FromServices] DataContext context,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 25
            ){

            var todos = await context.Todos
            .AsNoTracking()
            .Skip(skip)
            .Take(take)            
            .ToListAsync();

            return Ok(todos);
        }
    }


}