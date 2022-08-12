using InterviewTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewTask.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
        public decimal? ShoppingCartTotal { get; set; }
    }
}