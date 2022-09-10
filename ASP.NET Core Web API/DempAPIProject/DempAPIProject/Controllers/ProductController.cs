using DempAPIProject.Models;
using DempAPIProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DempAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository prodRepository;
        private readonly IProductRepository prodRepository1;

        public ProductController(IProductRepository Repository1, IProductRepository Repository2)
        {
            prodRepository = Repository1;
            prodRepository1 = Repository2;
        }

        [HttpPost("")]
        public IActionResult AddProduct([FromBody]ProductModel product)
        {
            prodRepository.AddProduct(product);
            var allProducts = prodRepository1.GetAllProducts();
            return Ok(allProducts);
        }

        [HttpGet("")]
        public IActionResult GetName()
        {
            var name = prodRepository.GetName();
            return Ok(name);
        }
    }
}
