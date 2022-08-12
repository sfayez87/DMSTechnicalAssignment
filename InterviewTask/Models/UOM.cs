using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class UOM
    {
        public int Id { get; set; }
        [Display(Name = "Unit of Measure")]
        [StringLength(10)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}