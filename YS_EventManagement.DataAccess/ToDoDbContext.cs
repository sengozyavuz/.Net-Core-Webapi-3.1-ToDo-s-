using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YS_EventManagement.Entities;

namespace YS_EventManagement.DataAccess
{
    public class ToDoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = EventDB; Integrated Security = True; MultipleActiveResultSets = True;");
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
