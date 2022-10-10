using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpecsAPI.Models
{
    public class SpecModel
    {        
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
