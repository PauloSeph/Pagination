using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pagination.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class Paginacao : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            return Ok();
        }
    }
}