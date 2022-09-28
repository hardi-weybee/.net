using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Exercise_3.Models
{
    public class ProductModel
    {
        public int ID { get; set; }

        [Display(Name ="Product")]
        [Required(ErrorMessage ="Please Enter name")]
        public string ProductName { get; set; }
    }
}
