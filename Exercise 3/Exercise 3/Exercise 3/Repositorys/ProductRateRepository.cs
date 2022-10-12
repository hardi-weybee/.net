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
    public class ProductRateRepository : IProductRateRepository
    {
        private readonly InvoiceContext _context = null;
        private readonly IMapper _mapper;

        public ProductRateRepository(InvoiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProductRateModel> GetAllProductRate()
        {
            var records = _context.ProductRate.Include(x => x.Product).ToList();
            return _mapper.Map<List<ProductRateModel>>(records);
        }

        public async Task<int> SaveProductRate(ProductRateModel model)
        {
            var a = _context.ProductRate.Where(x => x.productID == model.productID).FirstOrDefault();
            if (a == null)
            {
                var records = new ProductRate()
                {
                    productID = model.productID,
                    Rate = model.Rate,
                    DateOfRate = model.DateOfRate
                };
                await _context.ProductRate.AddAsync(records);
                await _context.SaveChangesAsync();
                return records.ID;
            }
            return 0;
        }

        public async Task<int> EditProductRate(ProductRateModel model)
        {
            var a = _context.ProductRate.Where(x => x.productID == model.productID && x.Rate == model.Rate && x.DateOfRate == model.DateOfRate).FirstOrDefault();
            if (a == null)
            {
                var records = new ProductRate()
                {
                    ID = model.ID,
                    productID = model.productID,
                    Rate = model.Rate,
                    DateOfRate = model.DateOfRate
                };
                _context.ProductRate.Update(records);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 2;
        }

        public async Task<bool> DeleteProductRate([FromRoute] int id)
        {
            var records = new ProductRate()
            {
                ID = id
            };
            _context.ProductRate.Remove(records);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
