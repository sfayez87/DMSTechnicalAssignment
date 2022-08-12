using InterviewTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewTask.Models;

namespace InterviewTask.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ShoppingCartRepository shoppingCartRepository;
        public OrderRepository()
        {
            context = new ApplicationDbContext();
            shoppingCartRepository = new ShoppingCartRepository();
        }
        /// <summary>
        /// This method creates a new order using the shopping cart items
        /// </summary>
        /// <param name="shoppingCartItems"></param>
        /// <param name="customerCode"></param>
        public void CreateOrder(List<ShoppingCartItem> shoppingCartItems, int customerCode)
        {
            OrderHeader orderHeader = new OrderHeader {
                OrderDate = DateTime.Today,
                Status = "Open",
                DueDate = DateTime.Today.AddDays(1),
                TaxCode = 14,
                CustomerCode=customerCode
            };
            orderHeader.OrderDetails = new List<OrderDetail>();
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                orderHeader.OrderDetails.Add(new OrderDetail
                {
                    ItemId=shoppingCartItem.ItemId,
                    ItemName=shoppingCartItem.ItemName,
                    ItemDescription=shoppingCartItem.ItemDescription,
                    ItemPrice=shoppingCartItem.Price,
                    Qty=shoppingCartItem.Qty,
                    TotalPrice= shoppingCartItem.Price * shoppingCartItem.Qty,
                    DiscountCode=shoppingCartItem.DiscountCode,
                    DiscountValue= shoppingCartItem.Price * shoppingCartItem.Qty * shoppingCartItem.DiscountCode / 100,
                    UOMName=shoppingCartItem.UOMName
                });
               var itemsQtyBalance= context.Items.SingleOrDefault(i => i.Id == shoppingCartItem.ItemId).Qty;
                itemsQtyBalance = -shoppingCartItem.Qty;
            }
            orderHeader.DiscountValue = orderHeader.OrderDetails.Select(s => s.DiscountValue).Sum();
            orderHeader.TaxValue = orderHeader.OrderDetails.Select(s => s.TotalPrice).Sum() * orderHeader.TaxCode / 100;
            orderHeader.TotalPrice = (orderHeader.OrderDetails.Select(s => s.TotalPrice).Sum() + orderHeader.TaxValue) - orderHeader.DiscountValue;
            context.OrderHeaders.Add(orderHeader);
            context.SaveChanges();
            foreach (var item in orderHeader.OrderDetails)
            {
                item.OrderId = orderHeader.Id;
            }
            context.SaveChanges();
            shoppingCartRepository.ClearCart(shoppingCartItems.FirstOrDefault().ShoppingCartId);
        }
        /// <summary>
        /// This method gets the order details items
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Returns a list of order details items</returns>
        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return context.OrderDetails.Where(o => o.OrderId == orderId).ToList();
        }
        /// <summary>
        /// This method gets the order header
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>Returns the order header</returns>
        public OrderHeader GetOrderHeader(int customerCode)
        {
            return context.OrderHeaders
                .Where(o => o.CustomerCode == customerCode && o.Id==context.OrderHeaders.Max(i=>i.Id))
                .SingleOrDefault();
        }
    }
}