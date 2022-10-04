using Exercise_3.Models;
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

        
        [HttpGet("EditProductRate/{id}/{proname}/{rate}/{rdate}")]
        public ViewResult EditProductRate([FromRoute] int id, [FromRoute] int proname, [FromRoute] int rate, [FromRoute] DateTime rdate, int isSuccess = 0)
        {
            ViewBag.DateOfRate = rdate.ToString("yyyy-MM-dd");
            ViewBag.Success = isSuccess;
            ViewBag.ID = id;
            ProductRateModel rateModel = new ProductRateModel()
            {
                productID = proname,
                Rate = rate,
                DateOfRate = rdate
            };
            return View("AddProductRate", rateModel);
        }

        [HttpPost("EditProductRate/{id}/{proname}/{rate}/{rdate}")]
        public async Task<IActionResult> EditProductRate(ProductRateModel model, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var suc = await _rateRepo.EditProductRate(model, id);
                if (id > 0)
                {
                    return RedirectToAction(nameof(EditProductRate), new { isSuccess = suc, ProductRateId = id });
                }
                return RedirectToAction(nameof(EditProductRate), new { isSuccess = 2 });
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