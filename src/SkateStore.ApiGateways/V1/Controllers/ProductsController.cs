using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkateStore.ApiGateways.Services;
using SkateStore.ApiGateways.ViewModel;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SkateStore.ApiGateways.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IHttpClientProvider _httpClient;
        public ProductsController(IHttpClientProvider httpClient)
        {
            _httpClient = httpClient;
        }

        [AllowAnonymous]
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var products = await _httpClient.GetAsync<List<ProductViewModel>>("https://localhost:44333", "api/products?v=1.0");

            if (products is null)
                return BadRequest();

            return Ok(products);            
        }


        // POST: api/Product
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductViewModel data)
        {

            var result = await _httpClient.PostHttpRequest<ProductViewModel>("https://localhost:44333", "api/products?v=1.0", data);

            if (result is null)
                return BadRequest();

            if (result.IsSuccessStatusCode)
                return StatusCode(201);
            else
                return BadRequest();
        }        
    }
}
