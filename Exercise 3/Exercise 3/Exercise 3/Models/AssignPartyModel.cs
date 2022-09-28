using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Exercise_3.Data;
using System.ComponentModel.DataAnnotations;

namespace Exercise_3.Models
{
    public class AssignPartyModel
    {
        public int ID { get; set; }

        [Display(Name = "Party")]
        [ForeignKey("Party")]
        public int partyID { get; set; }

        [Display(Name = "Product")]
        [ForeignKey("Product")]
        public int productID { get; set; }

        public string PartyName { get; set; }
        public string ProductName { get; set; }

        public Party Party { get; set; }

        public Product Product { get; set; }
    }
}
