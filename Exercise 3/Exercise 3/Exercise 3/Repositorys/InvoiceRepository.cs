using AutoMapper;
using Exercise_3.Data;
using Exercise_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_3.Repositorys
{
    public class InvoiceRepository
    {
        private readonly InvoiceContext _context = null;
        private readonly IMapper _mapper;

        public InvoiceRepository(InvoiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddInvoice(InvoiceModel model, int id)
        {
            var records = new Invoice()
            {
                partyID = model.partyID,
                productID = model.productID,
                CurrentRate = model.CurrentRate,
                Quantity = model.Quantity,
                Total = (model.Quantity * model.CurrentRate)
            };

            await _context.Invoice.AddAsync(records);
            await _context.SaveChangesAsync();

            int grandTotal = (from x in _context.Invoice.Where(x => x.partyID == id) select x.Total).Sum();
            return grandTotal;
        }

        public async Task<List<InvoiceModel>> DisplayTable(int _partyid)
        {
            var partyList = await _context.Invoice.Where(x=>x.partyID==_partyid)
                .Select(a => new InvoiceModel()
                {
                    ID = a.ID,
                    partyID = a.partyID,
                    productID = a.productID,
                    PartyName = _context.Party.Where(x => x.ID == a.partyID).FirstOrDefault().PartyName,
                    ProductName = _context.Product.Where(x => x.ID == a.productID).FirstOrDefault().ProductName,
                    CurrentRate = a.CurrentRate,
                    Quantity = a.Quantity,
                    Total = (a.Quantity * a.CurrentRate),
                }).ToListAsync();
            return _mapper.Map<List<InvoiceModel>>(partyList);
        }

        public async Task<List<AssignPartyModel>> getProductByParty(int partyid)
        {
            return await _context.AssignParty.Where(x => x.partyID == partyid)
                .Select(x => new AssignPartyModel()
                {
                    ProductName = x.Product.ProductName,
                    productID = x.productID
                }).ToListAsync();
        }

        public async Task<int> getRateByProduct(int productid)
        {
            var rates = await _context.ProductRate.Where(x => x.productID == productid)
                .Select(x => x.Rate).FirstOrDefaultAsync();
            return rates;
        }
    }
}
