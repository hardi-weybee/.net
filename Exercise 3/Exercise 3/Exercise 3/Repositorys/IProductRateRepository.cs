using Exercise_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise_3.Repositorys
{
    public interface IProductRateRepository
    {
        Task<bool> DeleteProductRate([FromRoute] int id);
        Task<int> EditProductRate(ProductRateModel model);
        List<ProductRateModel> GetAllProductRate();
        Task<int> SaveProductRate(ProductRateModel model);
    }
}