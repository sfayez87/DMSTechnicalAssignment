using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.ViewModels
{
    public class OrderViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}