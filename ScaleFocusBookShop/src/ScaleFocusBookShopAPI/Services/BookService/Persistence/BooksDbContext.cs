using BookService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Persistence
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author() { Id = 1, FullName = "Leo Tolstoy" },
                new Author() { Id = 2, FullName = "William Shakespeare" },
                new Author() { Id = 3, FullName = "Mark Twain" }
            );

            modelBuilder.Entity<Book>().HasData(
               new Book() { Id = 1, Title = "War and peace", Synopsis = "The novel chronicles the French invasion of Russia and the impact of the Napoleonic era...", Genre = BookGenre.Novel, AuthorId = 1, Price = 200 },
               new Book() { Id = 2, Title = "Romeo and Juliet", Synopsis = "In Romeo and Juliet, Shakespeare creates a violent world, in which two young people fall in love...", Genre = BookGenre.Romance, AuthorId = 2, Price = 300 },
               new Book() { Id = 3, Title = "The Adventures of Huckleberry Finn", Synopsis = "A nineteenth-century boy from a Mississippi River town recounts his adventures...", Genre = BookGenre.Fiction, AuthorId = 3, Price = 400 },
               new Book() { Id = 4, Title = "Ana Karenina", Synopsis = "It deals with themes of betrayal, faith, family, marriage, Imperial Russian society, desire, and rural vs. city life....", Genre = BookGenre.Novel, AuthorId = 1, Price = 200 },
               new Book() { Id = 5, Title = "Hamlet", Synopsis = "Set in Denmark, the play depicts Prince Hamlet and his revenge against his uncle, Claudius, who has murdered Hamlet's father in order to seize his throne and marry Hamlet's mother....", Genre = BookGenre.Drama, AuthorId = 2, Price = 300 },
               new Book() { Id = 6, Title = "The Adventures of Tom Sawyer", Synopsis = " It is set in the 1840s in the fictional town of St. Petersburg, inspired by Hannibal, Missouri, where Twain lived as a boy....", Genre = BookGenre.Novel, AuthorId = 3, Price = 400 }
           );
        }
    }
}
