using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Models
{
    [Table("Author", Schema = "dbo")]
    public class Author
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
