using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int? Qty { get; set; }
        public string UOMName { get; set; }
        public decimal? Price { get; set; }
        public decimal? SubTotalPrice { get; set; }
        public int? DiscountCode { get; set; }
        public Item Item { get; set; }
        public string ShoppingCartId { get; set; }
    }
}