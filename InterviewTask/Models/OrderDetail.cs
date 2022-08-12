using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal? ItemPrice { get; set; }
        public int? Qty { get; set; }
        public decimal? TotalPrice { get; set; }
        public string UOMName{ get; set; }
        public int? DiscountCode { get; set; }
        public decimal? DiscountValue { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public Item Item { get; set; }
    }
}