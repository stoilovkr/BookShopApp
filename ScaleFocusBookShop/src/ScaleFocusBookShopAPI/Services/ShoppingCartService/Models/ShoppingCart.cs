using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartService.Models
{
    [Table("ShoppingCart", Schema = "dbo")]
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int IdentityId { get; set; }

        public DateTime OrderTimeStamp { get; set; }

        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }

        [NotMapped]
        public double Total { get; set; }

        public ShoppingCart()
        {
            ShoppingCartDetails = new List<ShoppingCartDetail>();
        }
    }
}
