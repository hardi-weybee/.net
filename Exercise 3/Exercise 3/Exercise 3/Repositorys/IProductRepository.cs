using Exercise_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise_3.Repositorys
{
    public interface IProductRepository
    {
        Task<bool> DeleteProduct([FromRoute] int id);
        Task<int> EditProduct(ProductModel model);
        Task<List<ProductModel>> GetAllProduct();
        Task<int> SaveProduct(ProductModel model);
        //Task<object> getProductsNotAssigned(int partyID);
    }
}