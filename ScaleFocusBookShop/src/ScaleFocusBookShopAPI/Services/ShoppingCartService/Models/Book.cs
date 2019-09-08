using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartService.Models
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
    }
}
