using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartService.Models
{
    [Table("ShoppingCartDetails", Schema = "dbo")]
    public class ShoppingCartDetail
    {
        public int Id { get; set; }

        [ForeignKey("ShoppingCartId")]
        public int ShoppingCartId { get; set; }

        public int BookId { get; set; }

        public double Price { get; set; }

        [NotMapped]
        public virtual Book BookEntity { get; set; }

        public virtual ShoppingCart ShoppingCartEntity { get; set; }
    }
}
