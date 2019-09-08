using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShoppingCartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartService
{
    public static class SessionHelpers
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static ICollection<ShoppingCartDetail> ParseShoppingCartItemsFromSession(this ISession session)
        {
            var shoppingCartDetails = session.GetObjectFromJson<ICollection<ShoppingCartDetail>>(key: "ShoppingCartDetails");
            if (shoppingCartDetails == null)
            {
                shoppingCartDetails = new List<ShoppingCartDetail>();
            }

            return shoppingCartDetails;
        }
    }
}
