﻿// <auto-generated />
using System;
using Lab_4_MVC_Razor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab_4_MVC_Razor.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220603102039_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab_4_MVC_Razor.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            BookName = "Emil i lönneberga"
                        },
                        new
                        {
                            BookId = 2,
                            BookName = "Pippi Långstrump"
                        },
                        new
                        {
                            BookId = 3,
                            BookName = "Mio Min Mio"
                        });
                });

            modelBuilder.Entity("Lab_4_MVC_Razor.Models.Borrowing", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("date");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("date");

                    b.HasKey("BorrowId");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Borrowings");
                });

            modelBuilder.Entity("Lab_4_MVC_Razor.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerAddress = "Address 1",
                            CustomerEmail = "Carl.Persson@email.com",
                            CustomerName = "Carl Persson",
                            CustomerNumber = "61856036"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerAddress = "Address 2",
                            CustomerEmail = "Charlie.Andersson@email.com",
                            CustomerName = "Charlie Andersson",
                            CustomerNumber = "42869518"
                        },
                        new
                        {
                            CustomerId = 3,
                            CustomerAddress = "Address 3",
                            CustomerEmail = "Karin.Strom@email.com",
                            CustomerName = "Karin Ström",
                            CustomerNumber = "55783342"
                        });
                });

            modelBuilder.Entity("Lab_4_MVC_Razor.Models.Borrowing", b =>
                {
                    b.HasOne("Lab_4_MVC_Razor.Models.Book", "Books")
                        .WithMany("Borrowings")
                        .HasForeignKey("BookId");

                    b.HasOne("Lab_4_MVC_Razor.Models.Customer", "Customer")
                        .WithMany("Borrowings")
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}