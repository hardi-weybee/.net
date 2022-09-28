using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exercise_3.Data
{
    public class AssignParty
    {
        public int ID { get; set; }

        [Display(Name = "Party")]
        [ForeignKey("Party")]
        public int partyID { get; set; }

        [ForeignKey("Product")]
        [Display(Name = "Product")]
        public int productID { get; set; }

        public Party Party { get; set; }

        public Product Product { get; set; }
    }
}
