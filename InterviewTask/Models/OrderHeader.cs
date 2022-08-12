using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        public int CustomerCode { get; set; }
        public int? TaxCode { get; set; }
        public decimal? TaxValue { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}