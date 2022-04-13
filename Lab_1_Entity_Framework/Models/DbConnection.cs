using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1_Entity_Framework.Models
{
    class DbConection : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab1_ASP_Course;Integrated Security=True");
        }
    }
}
