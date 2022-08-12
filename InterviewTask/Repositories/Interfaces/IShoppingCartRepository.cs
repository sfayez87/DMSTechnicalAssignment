using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        List<ShoppingCartItem> GetShoppingCartItems(string cartId);
        void AddToCart(Item item,string cartId);
        void RemoveFromCart(int id);
        void ClearCart(string cartId);
        decimal? GetShoppingCartTotal(string cartId);

    }
}
