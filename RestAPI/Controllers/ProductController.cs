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
    public class ProductController: ControllerBase
    {
        protected readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProduct()
        {
            var results =await _productService.GetAllProductAsync();
            return Ok(results);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var results = await _productService.GetProductByIdAsync(id);
            return Ok(results);
        }
    }
}
