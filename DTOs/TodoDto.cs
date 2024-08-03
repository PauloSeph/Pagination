using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.DTOs
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}