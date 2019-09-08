using BookService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Services
{
    public interface IBooksService
    {
        Book GetBookById(int id);

        IEnumerable<Book> GetAllBooks();

        IEnumerable<Book> GetBooksByAuthor(string authorFullName);

        IEnumerable<Book> GetBooksByGenre(string genreName);

        void AddBook(Book book, string authorFullName);
    }
}
