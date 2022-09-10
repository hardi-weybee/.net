using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Specss.API.Data;
using Specss.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specss.API.Repository
{
    public class SpecssRepository : ISpecssRepository
    {
        private readonly SpecsContext _context;
        private readonly IMapper _mapper;

        public SpecssRepository(SpecsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SpecsModel>> GetAllSpecsAsync()
        {
            var records = await _context.Specs.ToListAsync();         
            return _mapper.Map<List<SpecsModel>>(records);
        }

        public async Task<SpecsModel> GetSpecsByIDAsync(int specID)
        {
            //var records = await _context.Specs.Where(x => x.ID == specID).Select(x => new SpecsModel()
            //{
            //    ID = x.ID,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();

            //return records;

            var spec = await _context.Specs.FindAsync(specID);
            return _mapper.Map<SpecsModel>(spec);
        }

        public async Task<int> AddSpecAsync(SpecsModel specModel)
        {
            var spec = new Specs()
            {
                Title = specModel.Title,
                Description = specModel.Description
            };

            _context.Specs.Add(spec);
            await _context.SaveChangesAsync();

            return spec.ID;
        }

        public async Task UpdateSpecsAsync(int specID, SpecsModel specModel)
        {
            //var spec = await _context.Specs.FindAsync(specID);
            //if (spec != null)
            //{
            //    spec.Title = specModel.Title;
            //    spec.Description = specModel.Description;
            //    await _context.SaveChangesAsync();
            //}

            var spec = new Specs()
            {
                ID = specID,
                Title = specModel.Title,
                Description = specModel.Description
            };

            _context.Specs.Update(spec);
            await _context.SaveChangesAsync();                        
        }

        public async Task UpdateSpecPatchAsync(int specID, JsonPatchDocument specModel)
        {
            var spec = await _context.Specs.FindAsync(specID);
            if (spec != null)
            {
                specModel.ApplyTo(spec);
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteSpecAsync(int specID)
        {
            var spec = new Specs() { ID = specID };

            _context.Specs.Remove(spec);
            await _context.SaveChangesAsync();
        }
    }
}
