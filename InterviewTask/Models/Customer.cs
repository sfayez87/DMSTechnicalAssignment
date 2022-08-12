using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class Customer
    {
        [Key]
        public int CustomerCode { get; set; }
        public string ENDescription { get; set; }
        public string ARDescription { get; set; }
    }
}