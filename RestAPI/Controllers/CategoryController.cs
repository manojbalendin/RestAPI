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
    public class CategoryController: ControllerBase
    {
        protected readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategorytById(int id)
        {
            var results = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(results);
        }
    }
}
