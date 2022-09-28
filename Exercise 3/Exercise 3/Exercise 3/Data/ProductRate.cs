using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_3.Data
{
    public class ProductRate
    {
        public int ID { get; set; }

        [Display(Name = "Product")]
        [ForeignKey("Product")]
        public int productID { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime DateOfRate { get; set; }

        public Product Product { get; set; }
    }
}
