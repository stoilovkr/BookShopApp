using Microsoft.EntityFrameworkCore;
using ShoppingCartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartService.Persistence
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {
        }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
               new Book() { Id = 1, Title = "War and peace", Price = 200 },
               new Book() { Id = 2, Title = "Romeo and Juliet", Price = 300 },
               new Book() { Id = 3, Title = "The Adventures of Huckleberry Finn", Price = 400 },
               new Book() { Id = 4, Title = "Ana Karenina", Price = 200 },
               new Book() { Id = 5, Title = "Hamlet", Price = 300 },
               new Book() { Id = 6, Title = "The Adventures of Tom Sawyer", Price = 400 }
           );

            modelBuilder.Entity<ShoppingCartDetail>().Ignore(x => x.BookEntity);
        }
    }
}
