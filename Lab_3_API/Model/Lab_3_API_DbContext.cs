using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3_API.Model
{
    public class Lab_3_API_DbContext : DbContext
    {
        public Lab_3_API_DbContext(DbContextOptions<Lab_3_API_DbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<Interest> Interests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
