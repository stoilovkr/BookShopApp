using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCartService.Models;
using ShoppingCartService.Services;
using System;
using System.Collections.Generic;

namespace ShoppingCartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService _shoppingCartService)
        {
            shoppingCartService = _shoppingCartService;
        }

        [HttpPost("shoppingcartdetails")]
        public IActionResult ShoppingCartDetails([FromBody] object obj)
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartDetails = HttpContext.Session.ParseShoppingCartItemsFromSession();
            var total = 0.0;
            foreach(var detail in shoppingCart.ShoppingCartDetails)
            {
                total += detail.Price;
            }
            shoppingCart.Total = total;
            return new OkObjectResult(shoppingCart);
        }

        [HttpPost("additem")]
        public IActionResult AddItem([FromBody] ShoppingCartDetail detail)
        {
            shoppingCartService.Items = HttpContext.Session.ParseShoppingCartItemsFromSession();
            shoppingCartService.Items.Add(detail);
            HttpContext.Session.SetObjectAsJson(key: "ShoppingCartDetails", value: shoppingCartService.Items);

            return new OkResult();
        }

        [HttpPost("removeitem")]
        public IActionResult RemoveItem([FromBody] ShoppingCartDetail detail)
        {
            shoppingCartService.Items = HttpContext.Session.ParseShoppingCartItemsFromSession();
            shoppingCartService.Items.Remove(detail);
            HttpContext.Session.SetObjectAsJson(key: "ShoppingCartDetails", value: shoppingCartService.Items);

            return new OkResult();
        }

        [HttpPost("finishorder")]
        public IActionResult FinishOrder([FromBody] ShoppingCart shoppingCart)
        {
            if(shoppingCart.ShoppingCartDetails == null || shoppingCart.ShoppingCartDetails.Count == 0)
            {
                return new OkObjectResult("You don't have any items in your shopping cart.");
            }

            shoppingCart.OrderTimeStamp = DateTime.Now;
            var message = shoppingCartService.FinishShoping(shoppingCart);
            HttpContext.Session.SetString(key: "ShoppingCartDetails", value: string.Empty);

            return new OkObjectResult(JsonConvert.SerializeObject(message));
        }
    }
}