using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        OrderHeader GetOrderHeader(int customerCode);
        List<OrderDetail> GetOrderDetails(int orderId);
        void CreateOrder(List<ShoppingCartItem> shoppingCartItems,int customerCode);
    }
}
