using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Domain;
using RestApi.Services;
using RestApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DeveloperController: ControllerBase
    {
        protected readonly IDeveloperService _developerService;
        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDevelopers()
        {
            var developer =await _developerService.GetAllDevelopersAsync();
            return Ok(developer);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeveloperById(int id)
        {
            var developer = await _developerService.GetDevelopersByIdAsync(id);
            return Ok(developer);
        }
        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeveloperByEmail(string email)
        {
            var developer = await _developerService.GetDevelopersByEmailAsync(email);
            return Ok(developer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddDeveloper([FromBody] Developer developer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _developerService.AddDeveloper(developer);
            return CreatedAtAction(nameof(GetDeveloperById), new { Id = developer.Id }, developer);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _developerService.UpdateDeveloper(developer);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteDeveloper(int id)
        {
            _developerService.DeleteDeveloper(id);
            return Ok();
        }
    }
}
