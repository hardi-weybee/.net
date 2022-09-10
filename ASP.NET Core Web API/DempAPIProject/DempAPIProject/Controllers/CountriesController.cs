using DempAPIProject.CustomModelBinder;
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
    [BindProperties]
    public class CountriesController : ControllerBase
    {
        //// using bind property & bind properties attribute
        ////[BindProperty]
        //public CountryModel Country { get; set; }

        //[HttpPost("")]
        //public IActionResult AddCountry()
        //{
        //    return Ok($"Name = {this.Country.Name}, " +
        //        $"Population = {this.Country.Population}, " +
        //        $"Area = {this.Country.Area}");
        //}

        //// using from route & from query attribute
        //[HttpPost("{Name}/{Population}/{Area}")]
        //public IActionResult AddCountry([FromRoute]CountryModel country)
        //{
        //    return Ok($"Name = {country.Name}, Population = {country.Population}, Area = {country.Area}");
        //}

        //// using fron body attribute
        //[HttpPost("{id}")]
        //public IActionResult AddCountry([FromBody]int id)
        //{
        //    return Ok($"ID = {id}");
        //}

        //// using from form attribute
        //[HttpPost("{id}")]
        //public IActionResult AddCountry([FromRoute]int id, [FromForm]string x)
        //{
        //    return Ok($"Name = {x}");
        //}

        //// using from header attribute
        //[HttpPost("{id}")]
        //public IActionResult AddCountry([FromRoute] int id, [FromHeader] string x)
        //{
        //    return Ok($"Name = {x}");
        //}

        //// custom model binder (Example 1)
        //[HttpGet("search")]
        //public IActionResult SearchCountries([ModelBinder(typeof(CustomBinder))] string[] countries)
        //{
        //    return Ok(countries);
        //}

        // custom model binder (Example 2)
        [HttpGet("{id}")]
        public IActionResult CountryDetails([ModelBinder(Name = "ID")]CountryModel country)
        {
            return Ok(country);
        }
    }
}
