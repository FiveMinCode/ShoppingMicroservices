using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Respository
{
    public interface IShoppingCartRepository
    {
        Task<Entities.ShoppingCart> GetBasket(string userName);
        Task<Entities.ShoppingCart> UpdateBasket(Entities.ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}
