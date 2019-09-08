using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCartService.Models;
using ShoppingCartService.Persistence;

namespace ShoppingCartService.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private ShoppingCart shoppingCart;
        private ShoppingCartDbContext shoppingCartDbContext;

        public ICollection<ShoppingCartDetail> Items
        {
            get
            {
                return shoppingCart.ShoppingCartDetails;
            }

            set
            {
                shoppingCart.ShoppingCartDetails = value;
            }
        }

        public ShoppingCartService(ShoppingCartDbContext _shoppingCartDbContext)
        {
            shoppingCart = new ShoppingCart();
            shoppingCartDbContext = _shoppingCartDbContext;
        }

        public int AddItem(ShoppingCartDetail shoppingCartDetail)
        {
            //shoppingCart.Items;
            //return shoppingCart.Items.Count() - 1;
            return 0;
        }

        public bool RemoveItem(int index)
        {
            try
            {
                var item = shoppingCart.ShoppingCartDetails.ElementAt(index);
                shoppingCart.ShoppingCartDetails.Remove(item);
            }
            catch(ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        public string FinishShoping(ShoppingCart shoppingCart)
        {
            shoppingCartDbContext.Add<ShoppingCart>(shoppingCart);
            try
            {
                shoppingCartDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                string message = e.Message;
                if(e.InnerException != null)
                {
                    message += Environment.NewLine;
                    message += "Inner exception:";
                    message += Environment.NewLine;
                    message += e.InnerException;
                    return message;
                }
            }
            return "Your order is successfuly saved.";
        }
    }
}
