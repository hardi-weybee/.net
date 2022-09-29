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
    public class ProductRepository : IProductRepository
    {
        private readonly InvoiceContext _context = null;
        private readonly IMapper _mapper;

        public ProductRepository(InvoiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            var productList = await _context.Product.ToListAsync();
            return _mapper.Map<List<ProductModel>>(productList);
        }

        public async Task<int> SaveProduct(ProductModel model)
        {
            var a = _context.Product.Where(x => x.ProductName == model.ProductName).FirstOrDefault();
            if (a == null)
            {
                var records = new Product()
                {
                    ProductName = model.ProductName
                };
                await _context.Product.AddAsync(records);
                await _context.SaveChangesAsync();
                return records.ID;
            }
            return 0;
        }

        public async Task<int> EditProduct(ProductModel model, [FromRoute] int id)
        {
            var a = _context.Product.Where(x => x.ProductName == model.ProductName).FirstOrDefault();
            if (a == null)
            {
                var records = new Product()
                {
                    ID = id,
                    ProductName = model.ProductName
                };
                _context.Product.Update(records);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 2;
        }

        public async Task<bool> DeleteProduct([FromRoute] int id)
        {
            var records = new Product()
            {
                ID = id
            };
            _context.Product.Remove(records);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
