using ShoppingCartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartService.Services
{
    public interface IShoppingCartService
    {
        ICollection<ShoppingCartDetail> Items { get; set; }

        int AddItem(ShoppingCartDetail book);

        bool RemoveItem(int index);

        string FinishShoping(ShoppingCart shoppingCart);
    }
}
