using Lab_4_MVC_Razor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_4_MVC_Razor.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().Property(c => c.CustomerName).IsRequired();

            modelBuilder.Entity<Book>().Property(c => c.BookName).IsRequired();

            modelBuilder.Entity<Borrowing>().HasKey(b => b.BorrowId);
            modelBuilder.Entity<Borrowing>().Property(b => b.BorrowDate).HasColumnType("date");
            modelBuilder.Entity<Borrowing>().Property(b => b.ReturnDate).HasColumnType("date");

            // seed Customer Table
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                CustomerName = "Carl Persson",
                CustomerAddress = "Address 1",
                CustomerEmail = "Carl.Persson@email.com",
                CustomerNumber = "61856036"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                CustomerName = "Charlie Andersson",
                CustomerAddress = "Address 2",
                CustomerEmail = "Charlie.Andersson@email.com",
                CustomerNumber = "42869518"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                CustomerName = "Karin Ström",
                CustomerAddress = "Address 3",
                CustomerEmail = "Karin.Strom@email.com",
                CustomerNumber = "55783342"
            });

            // seed Book Table
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                BookName = "Emil i lönneberga",
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 2,
                BookName = "Pippi Långstrump",
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 3,
                BookName = "Mio Min Mio",
            });
        }
    }
}
