using Exercise_3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_3.Models
{
    public class InvoiceModel
    {
        public int ID { get; set; }

        [Display(Name = "Party")]
        [Required]
        public int partyID { get; set; }

        [Display(Name = "Product")]
        [Required]
        public int productID { get; set; }

        [Required]
        [Display(Name = "Current Rate")]
        public int CurrentRate { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int Total { get; set; }

        public string PartyName { get; set; }
        public string ProductName { get; set; }
        ////public AssignParty AssignParty { get; set; }

        //public Party Party { get; set; }

        //public Product Product { get; set; }

        //public ProductRate ProductRate { get; set; }

    }
}
