using BookService.Models;
using BookService.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Services
{
    public class BooksService : IBooksService
    {
        private BooksDbContext booksDbContext;

        public BooksService(BooksDbContext _booksDbContext)
        {
            booksDbContext = _booksDbContext;
        }

        public void AddBook(Book book, string authorFullName)
        {
            var author = booksDbContext.Add<Author>(new Author() { FullName = authorFullName });
            booksDbContext.SaveChanges();
            book.AuthorId = author.Entity.Id;
            booksDbContext.Add<Book>(book);
        }
        
        public Book GetBookById(int id)
        {
            var book = booksDbContext.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                book .AuthorEntity = booksDbContext.Authors.FirstOrDefault(x => x.Id == book.AuthorId);
            }

            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var books = booksDbContext.Books;
            var authors = booksDbContext.Authors;
            books.FillAuthorEntityProperty(authors);
            books.FillGenreNameProperty();

            return books;
        }

        public IEnumerable<Book> GetBooksByAuthor(string authorFullName)
        {
            IEnumerable<Book> booksByAuthor = new List<Book>();
            var books = booksDbContext.Books;
            var authors = booksDbContext.Authors;
            var author = booksDbContext.Authors.FirstOrDefault(x => x.FullName == authorFullName);
            if(author != null)
            {
                booksByAuthor = books.Where(x => x.AuthorId == author.Id).ToList();
            }

            booksByAuthor.FillAuthorEntityProperty(authors);
            booksByAuthor.FillGenreNameProperty();

            return booksByAuthor;
        }

        public IEnumerable<Book> GetBooksByGenre(string genreName)
        {
            var booksByGenre = new List<Book>();
            var books = booksDbContext.Books;
            var authors = booksDbContext.Authors;
            BookGenre genre;
            if (!Enum.TryParse(genreName, out genre))
            {
                return booksByGenre;
            }

            booksByGenre = books.Where(x => x.Genre == genre).ToList();
            booksByGenre.FillAuthorEntityProperty(authors);
            booksByGenre.FillGenreNameProperty();

            return booksByGenre;
        }
    }
}
