using InterviewTask.Models;
using InterviewTask.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTask.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext context;
        public ShoppingCartRepository()
        {
            context = new ApplicationDbContext();
        }

        /// <summary>
        /// This method adds new item to the shopping cart
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cartId"></param>
        public void AddToCart(Item item, string cartId)
        {
            var shoppingCartItem =
                    context.ShoppingCartItems.SingleOrDefault(
                        s => s.Item.Id == item.Id && s.ShoppingCartId == cartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem { ItemId = item.Id,ItemName= item.Name,ItemDescription=item.Description,Price = item.Price, SubTotalPrice = item.Price * 1,DiscountCode=item.DiscountCode,UOMName=item.UOMName, Qty = 1, ShoppingCartId = cartId };
                context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Qty++;
                shoppingCartItem.SubTotalPrice = item.Price * shoppingCartItem.Qty;
            }
            context.SaveChanges();
        }
        /// <summary>
        /// This method removes all items in the shopping cart
        /// </summary>
        /// <param name="cartId"></param>
        public void ClearCart(string cartId)
        {
            var cartItems = context.ShoppingCartItems.Where(i => i.ShoppingCartId == cartId);
            context.ShoppingCartItems.RemoveRange(cartItems);
            context.SaveChanges();
        }
        /// <summary>
        /// This method gets the total price of the shopping cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns>Returns the total price of the shopping cart</returns>
        public decimal? GetShoppingCartTotal(string cartId)
        {
            var total = context.ShoppingCartItems.Where(c => c.ShoppingCartId == cartId)
            .Select(c => c.Item.Price * c.Qty).Sum();
            return total;
        }
        /// <summary>
        /// This method removes a specific item from the shopping cart
        /// </summary>
        /// <param name="id"></param>
        public void RemoveFromCart(int id)
        {
            var shoppingCartItem = context.ShoppingCartItems.Find(id);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Qty > 1)
                {
                    shoppingCartItem.Qty--;
                }
                else
                {
                    context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            context.SaveChanges();
        }
        /// <summary>
        /// This method gets all items from the shopping cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns>Returns a list of the shopping cart items</returns>
        public List<ShoppingCartItem> GetShoppingCartItems(string cartId)
        {
            return context.ShoppingCartItems.Where(c => c.ShoppingCartId == cartId).ToList();
        }
    }
}