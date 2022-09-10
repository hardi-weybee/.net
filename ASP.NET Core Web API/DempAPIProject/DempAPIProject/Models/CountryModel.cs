using DempAPIProject.CustomModelBinder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DempAPIProject.Models
{
    [ModelBinder(typeof(CustomBinder2))]
    public class CountryModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Population { get; set; }

        public int Area { get; set; }
    }
}
