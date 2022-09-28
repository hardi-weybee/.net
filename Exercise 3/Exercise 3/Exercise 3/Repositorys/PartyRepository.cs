using AutoMapper;
using Exercise_3.Data;
using Exercise_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_3.Repositorys
{
    public class PartyRepository
    {
        private readonly InvoiceContext _context = null;
        private readonly IMapper _mapper;

        public PartyRepository(InvoiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> SaveParty(PartyModel model)
        {
            var a = _context.Party.Where(x => x.PartyName == model.PartyName).FirstOrDefault();
            if(a == null)
            {
                var records = new Party()
                {
                    PartyName = model.PartyName
                };
                await _context.Party.AddAsync(records);
                await _context.SaveChangesAsync();
                return records.ID;
            }
            return 0;

        }

        public async Task<int> EditParty(PartyModel model, [FromRoute]int id)
        {
            var a = _context.Party.Where(x => x.PartyName == model.PartyName).FirstOrDefault();
            if (a == null)
            {
                var records = new Party()
                {
                    ID = id,
                    PartyName = model.PartyName
                };

                _context.Party.Update(records);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 2;
        }

        public async Task<bool> DeleteParty([FromRoute] int id)
        {
            var records = new Party()
            {
                ID = id
            };

            _context.Party.Remove(records);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PartyModel>> GetAllParty()
        {
            var partyList = await _context.Party.ToListAsync();            
            return _mapper.Map<List<PartyModel>>(partyList);
        }
    }
}
