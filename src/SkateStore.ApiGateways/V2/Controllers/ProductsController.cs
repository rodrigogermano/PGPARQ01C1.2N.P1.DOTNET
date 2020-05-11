using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productsbuf;
using SkateStore.ApiGateways.ViewModel;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SkateStore.ApiGateways.V2.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {            
            var channel = GrpcChannel.ForAddress("https://localhost:5002");            
            var client = new ProductsBuf.ProductsBufClient(channel);

            var response = await client.GetAsync(new Empty());


            return Ok(response);
        }


        // POST: api/Product
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductViewModel data)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5002");
            var client = new ProductsBuf.ProductsBufClient(channel);

            var response = await client.PostAsync(new ProductBuf { 
                Name = data.Name,
                Description = data.Description,
                Price = Convert.ToInt64(data.Price),
                Photo = data.Photo
            });

            if (response.StatusCode == 201)
                return StatusCode(201);
            else
                return BadRequest();
        }
    }
}

