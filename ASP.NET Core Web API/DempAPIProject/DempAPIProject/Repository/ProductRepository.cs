using DempAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DempAPIProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductModel> productList = new List<ProductModel>();
        public int AddProduct(ProductModel product)
        {
            product.ID = productList.Count + 1;
            productList.Add(product);
            return product.ID;
        }

        public List<ProductModel> GetAllProducts()
        {
            return productList;
        }

        public string GetName()
        {
            return "Helooooooo PRODUCT";
        }
    }
}
