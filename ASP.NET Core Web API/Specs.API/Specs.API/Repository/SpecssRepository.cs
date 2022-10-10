using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SpecsAPI.Repository;
using SpecsAPI.Data;
using SpecsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecsAPI.Repository
{
    public class SpecssRepository : ISpecssRepository
    {
        private readonly SpecsDBContext _context;
        private readonly IMapper _mapper;

        public SpecssRepository(SpecsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SpecModel>> GetAllSpecsAsync()
        {
            var records = await _context.Specs.ToListAsync();         
            return _mapper.Map<List<SpecModel>>(records);
        }

        public async Task<SpecModel> GetSpecsByIDAsync(int specID)
        {
            //var records = await _context.Specs.Where(x => x.ID == specID).Select(x => new SpecsModel()
            //{
            //    ID = x.ID,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();

            //return records;

            var spec = await _context.Specs.FindAsync(specID);
            return _mapper.Map<SpecModel>(spec);
        }

        public async Task<int> AddSpecAsync(SpecModel specModel)
        {
            var spec = new Specss()
            {
                Title = specModel.Title,
                Description = specModel.Description
            };

            _context.Specs.Add(spec);
            await _context.SaveChangesAsync();

            return spec.ID;
        }

        public async Task UpdateSpecsAsync(int specID, SpecModel specModel)
        {
            //var spec = await _context.Specs.FindAsync(specID);
            //if (spec != null)
            //{
            //    spec.Title = specModel.Title;
            //    spec.Description = specModel.Description;
            //    await _context.SaveChangesAsync();
            //}

            var spec = new Specss()
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
            var spec = new Specss() 
            { 
                ID = specID 
            };

            _context.Specs.Remove(spec);
            await _context.SaveChangesAsync();
        }
    }
}
