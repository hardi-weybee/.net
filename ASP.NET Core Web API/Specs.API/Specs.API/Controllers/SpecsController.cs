using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Specss.API.Models;
using Specss.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specss.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecsController : ControllerBase
    {
        private readonly ISpecssRepository _specsRepository;

        public SpecsController(ISpecssRepository specsRepository)
        {
            _specsRepository = specsRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllSpecs()
        {
            var specs = await _specsRepository.GetAllSpecsAsync();
            return Ok(specs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecsByID([FromRoute] int id)
        {
            var spec = await _specsRepository.GetSpecsByIDAsync(id);
            if (spec == null)
            {
                return NotFound();
            }
            return Ok(spec);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewSpec([FromBody] SpecsModel specModel)
        {
            var id = await _specsRepository.AddSpecAsync(specModel);
            return CreatedAtAction(nameof(GetSpecsByID), new { id = id, Controller = "Specs"}, id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpec([FromBody] SpecsModel specModel, [FromRoute]int id)
        {
            await _specsRepository.UpdateSpecsAsync(id, specModel);
            return Ok();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSpecPatch([FromBody] JsonPatchDocument specModel, [FromRoute] int id)
        {
            await _specsRepository.UpdateSpecPatchAsync(id, specModel);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpec([FromRoute] int id)
        {
            await _specsRepository.DeleteSpecAsync(id);
            return Ok();
        }
    }
}
