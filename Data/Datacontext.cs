using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pagination.Models;

namespace Pagination.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStr = "Server=localhost;Port=3306;Database=PaginationApi;Uid=root;charset=utf8;";
            optionsBuilder.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
        }
    }
}