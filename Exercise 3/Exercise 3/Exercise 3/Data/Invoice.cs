using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_3.Data
{
    public class Invoice
    {
        public int ID { get; set; }

        [Display(Name = "Party")]
        public int partyID { get; set; }

        [Display(Name = "Product")]
        public int productID { get; set; }

        [Display(Name = "Current Rate")]
        public int CurrentRate { get; set; }

        public int Quantity { get; set; }

        public int Total { get; set; }

        //public AssignParty AssignParty { get; set; }

        //public Party Party { get; set; }

        //public Product Product { get; set; }

        //public ProductRate ProductRate { get; set; }
    }
}
