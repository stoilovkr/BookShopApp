using BookService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Services
{
    public static class BookServiceHelpers
    {
        public static IEnumerable<Book> FillGenreNameProperty(this IEnumerable<Book> books)
        {
            foreach(Book book in books)
            {
                book.GenreName = book.Genre.ToString();
            }

            return books;
        }

        public static IEnumerable<Book> FillAuthorEntityProperty(this IEnumerable<Book> books, IEnumerable<Author> authors)
        {
            foreach (Book book in books)
            {
                book.AuthorEntity = authors.FirstOrDefault(x => x.Id == book.AuthorId);
            }

            return books;
        }
    }
}
