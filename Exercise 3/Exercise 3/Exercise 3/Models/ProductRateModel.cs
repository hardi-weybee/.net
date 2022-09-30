using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Exercise_3.Data;

namespace Exercise_3.Models
{
    public class ProductRateModel
    {
        public int ID { get; set; }

        [Display(Name ="Product")]
        [Required(ErrorMessage = "Please select Product")]
        public int productID { get; set; }

        [Required(ErrorMessage = "Please Enter Rate")]
        public int Rate { get; set; }

        [Required(ErrorMessage ="Please select Date")]
        [Display(Name = "Date")]
        public DateTime DateOfRate { get; set; }

        public Product Product { get; set; }
    }
}
