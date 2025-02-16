﻿using Exercise_3.Models;
using Exercise_3.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exercise_3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo = null;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }


        public async Task<ViewResult> GetAllProduct()
        {
            var data = await _productRepo.GetAllProduct();
            return View(data);
        }


        [HttpGet]
        public ViewResult AddProduct(int isSuccess = 0)
        {
            ViewBag.Success = isSuccess;
            ViewBag.id = 0;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                int id = await _productRepo.SaveProduct(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddProduct), new { isSuccess = 1, id = 0 });
                }
                return RedirectToAction(nameof(AddProduct), new { isSuccess = 2 });
            }
            return View("AddProduct");
        }


        [HttpGet("EditProduct/{id}")]
        public ViewResult EditProduct([FromRoute]int id, string name, int isSuccess = 0)
        {
            ViewBag.Success = isSuccess;
            ViewBag.id = id;
            ViewBag.ProductName = name;
            ProductModel productModel = new ProductModel()
            {
                ID = id,
                ProductName = name
            };
            return View("AddProduct", productModel);
        }

        [HttpPost("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var suc = await _productRepo.EditProduct(model);
                if (model.ID > 0)
                {
                    return RedirectToAction(nameof(EditProduct), new { isSuccess = suc, ProductId = model.ID, name=model.ProductName });
                }
                return RedirectToAction(nameof(EditProduct), new { isSuccess = suc });
            }
            return View("AddProduct");
        }


        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            bool isdeleted = await _productRepo.DeleteProduct(id);
            if (isdeleted)
            {
                return RedirectToAction("GetAllProduct");
            }
            return null;
        }

        //public async Task<IActionResult> getProductsNotAssigned(int partyID)
        //{
        //    var product = await _productRepo.getProductsNotAssigned(partyID);
        //    return View(product);
        //}
    }
}
