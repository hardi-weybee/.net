﻿using DempAPIProject.Models;
using System.Collections.Generic;

namespace DempAPIProject.Repository
{
    public interface IProductRepository
    {
        int AddProduct(ProductModel product);
        List<ProductModel> GetAllProducts();

        string GetName();
    }
}