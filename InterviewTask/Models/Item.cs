using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Display(Name ="Item Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Quantity")]
        public int? Qty { get; set; }
        public decimal? Price { get; set; }

        [Display(Name = "Discount Code")]
        public int? DiscountCode { get; set; }
        public int UOMId { get; set; }
        [Display(Name = "Unit of Measure")]
        public string UOMName { get; set; }
        public UOM UOM { get; set; }
    }
}