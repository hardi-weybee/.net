using AutoMapper;
using Exercise_3.Data;
using Exercise_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_3.Repositorys
{
    public class AssignPartyRepository
    {
        private readonly InvoiceContext _context = null;
        private readonly IMapper _mapper;

        public AssignPartyRepository(InvoiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AssignPartyModel> GetAllAssignParty()
        {
            var records = _context.AssignParty.Include(x => x.Party).Include(x => x.Product).ToList();
            return _mapper.Map<List<AssignPartyModel>>(records);
        }

        public async Task<List<ProductModel>> getProductsNotAssigned(int partyid)
        {
            var store = await _context.Product.Except(_context.AssignParty.Where(x => x.partyID == partyid).Include(x => x.Product).Select(x => x.Product)).ToListAsync();
            return _mapper.Map<List<ProductModel>>(store);
        }

        public async Task<int> SaveAssignParty(AssignPartyModel model)
        {
            var records = new AssignParty()
            {
                partyID = model.partyID,
                productID = model.productID
            };
            await _context.AssignParty.AddAsync(records);
            await _context.SaveChangesAsync();
            return records.ID;
        }

        public async Task<int> EditAssignParty(AssignPartyModel model, [FromRoute] int id)
        {
            var a = _context.AssignParty.Where(x => x.partyID == model.partyID && x.productID == model.productID).FirstOrDefault();
            if(a == null)
            {
                var records = new AssignParty()
                {
                    ID = id,
                    partyID = model.partyID,
                    productID = model.productID
                };
                _context.AssignParty.Update(records);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 2;            
        }

        public async Task<bool> DeleteAssignParty([FromRoute] int id)
        {
            var records = new AssignParty()
            {
                ID = id
            };
            _context.AssignParty.Remove(records);
            await _context.SaveChangesAsync();
            return true;
        }       

        // Display unique party for invoice dropdown
        public async Task<List<AssignPartyModel>> UniqueParty()
        {
            return await _context.AssignParty.Select(assign => new AssignPartyModel()
            {
                partyID = assign.partyID,
                Party = assign.Party
            }).Distinct().ToListAsync();
        }
    } 
}