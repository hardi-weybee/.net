using DempAPIProject.Models;
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
    public class AnimalController : ControllerBase
    {
        private List<AnimalModel> animal = null;
        public AnimalController()
        {            
            animal = new List<AnimalModel>()
            {
                new AnimalModel() {ID=1, Name="Lion"},
                new AnimalModel() {ID=2, Name="Tiger"},
                new AnimalModel() {ID=3, Name="Elephant"}
            };
        }

        [Route("")]
        public IActionResult GetAnimalsOk()
        {            
            return Ok(animal);
        }

        [Route("test")]
        public IActionResult GetAnimalsAccepted()
        {            
            return Accepted(animal);
        }

        [Route("{name}")]
        public IActionResult GetAnimalsBadRequest(string name)
        {
            if (!name.Contains("z")) 
            {
                return BadRequest();
            }
            return Ok(animal);
        }

        [Route("{id:int}")]
        public IActionResult GetAnimalsID(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(animal.FirstOrDefault(x => x.ID == id));
        }

        [HttpPost("")]
        public IActionResult GetAnimalsCreated(AnimalModel a)
        {
            animal.Add(a);
            return Created("~/api/animal/"+a.ID, a);
        }
    }
}
