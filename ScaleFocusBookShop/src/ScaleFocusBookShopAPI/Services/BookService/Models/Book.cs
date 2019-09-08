using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Models
{
    [Table("Book", Schema = "dbo")]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Synopsis { get; set; }

        public BookGenre Genre { get; set; }

        [NotMapped]
        public string GenreName { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        public double Price { get; set; }

        public virtual Author AuthorEntity { get; set; }
    }

    public enum BookGenre { Novel, Drama, Mystery, Thriller, Romance, Science, Fiction }
}
