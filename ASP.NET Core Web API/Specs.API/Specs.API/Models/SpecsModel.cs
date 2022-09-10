using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Specss.API.Models
{
    public class SpecsModel
    {        
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
