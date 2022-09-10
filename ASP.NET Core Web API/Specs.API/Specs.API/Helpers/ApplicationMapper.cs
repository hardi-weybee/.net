using AutoMapper;
using Specss.API.Models;
using Specss.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specss.API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Specs, SpecsModel>().ReverseMap();
        }
    }
}
