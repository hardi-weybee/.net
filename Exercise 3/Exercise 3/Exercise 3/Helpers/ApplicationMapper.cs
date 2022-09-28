using AutoMapper;
using Exercise_3.Data;
using Exercise_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_3.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Party, PartyModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<AssignParty, AssignPartyModel>().ReverseMap();
            CreateMap<ProductRate, ProductRateModel>().ReverseMap();
            CreateMap<Invoice, InvoiceModel>().ReverseMap();
        }
    }
}
