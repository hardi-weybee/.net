using AutoMapper;
using SpecsAPI.Models;
using SpecsAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specs.API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Specss, SpecModel>().ReverseMap();
        }
    }
}
