using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkateStore.Api.Model;
using SkateStore.Api.ViewModel;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SkateStore.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsController(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }       

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var products = _mapper.Map<List<ProductViewModel>>(await _productRepository.GetAsync());

            return Ok(products);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductViewModel data)
        {
            var product = new Product(data.Name, data.Description, data.Price, data.Photo);

            if (_productRepository.Save(product) > 0)
                return StatusCode(201);

            return BadRequest();
        }
    }
}
