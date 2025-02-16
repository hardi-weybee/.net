﻿using Exercise_3.Models;
using Exercise_3.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Exercise_3.Controllers
{
    public class ProductRateController : Controller
    {
        private readonly IProductRateRepository _rateRepo = null;

        public ProductRateController(IProductRateRepository rateRepo)
        {
            _rateRepo = rateRepo;
        }


        public ViewResult GetAllProductRate()
        {
            var data = _rateRepo.GetAllProductRate();
            return View(data);
        }


        public ViewResult AddProductRate(int isSuccess = 0)
        {
            ViewBag.Success = isSuccess;
            ViewBag.ID = 0;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductRate(ProductRateModel model)
        {
            if (ModelState.IsValid)
            {
                int id = await _rateRepo.SaveProductRate(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddProductRate), new { isSuccess = 1, id=0 });
                }
                return RedirectToAction(nameof(AddProductRate), new { isSuccess = 2 });
            }
            return View("AddProductRate");
        }

        
        [HttpGet("EditProductRate/{id}")]
        public ViewResult EditProductRate([FromRoute] int id, int productname, int rate, DateTime rdate, int isSuccess = 0)
        {
            ViewBag.DateOfRate = rdate.ToString("yyyy-MM-dd");
            ViewBag.Success = isSuccess;
            ViewBag.ID = id;
            ProductRateModel rateModel = new ProductRateModel()
            {
                productID = productname,
                Rate = rate,
                DateOfRate = rdate
            };
            return View("AddProductRate", rateModel);
        }

        [HttpPost("EditProductRate/{id}")]
        public async Task<IActionResult> EditProductRate(ProductRateModel model)
        {
            if (ModelState.IsValid)
            {
                var suc = await _rateRepo.EditProductRate(model);
                if (model.ID > 0)
                {
                    return RedirectToAction(nameof(EditProductRate), new { isSuccess = suc, ProductRateId = model.ID });
                }
                return RedirectToAction(nameof(EditProductRate), new { isSuccess = suc });
            }
            return View("AddProductRate");
        }


        public async Task<IActionResult> DeleteProductRate([FromRoute] int id)
        {
            bool isdeleted = await _rateRepo.DeleteProductRate(id);
            if (isdeleted)
            {
                return RedirectToAction("GetAllProductRate");
            }
            return null;
        }
    }
}