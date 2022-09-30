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
        [Required(ErrorMessage ="Please Select Party")]
        public int partyID { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "Please Select Product")]
        public int productID { get; set; }

        [Required(ErrorMessage = "Please Enter Rate")]
        [Display(Name = "Current Rate")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int CurrentRate { get; set; }

        [Required(ErrorMessage ="Please Enter Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
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
