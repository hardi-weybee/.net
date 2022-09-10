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
    public class EmployeeController : ControllerBase
    {
        [Route("")]
        public List<EmployeeModel> GetEmployees()
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel() {ID=1, Name="Hardi"},
                new EmployeeModel() {ID=2, Name="Misari"},
                new EmployeeModel() {ID=3, Name="Rishit"}
            };
        }

        [Route("{id}")]
        public IActionResult GetEmployees(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(new List<EmployeeModel>()
            {
                new EmployeeModel() {ID=1, Name="Hardi"},
                new EmployeeModel() {ID=2, Name="Misari"},
                new EmployeeModel() {ID=3, Name="Rishit"}
            });
        }

        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmployeesBasicDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return new EmployeeModel() { ID = 1, Name = "Hardi" };
        }


        [HttpGet("name")]
        public IActionResult GetName([FromServices] IProductRepository prodRepository)
        {
            var name = prodRepository.GetName();
            return Ok(name);
        }
    }
}
