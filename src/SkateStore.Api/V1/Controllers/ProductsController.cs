﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var lista = new List<ProductViewModel>();
            lista.Add(new ProductViewModel
            {
                Id = 1,
                Name = "a",
                Description = "a",
                Price = 10,
                Photo = "https://scene7.zumiez.com/is/image/zumiez/pdp_hero/Superior-Glow-Propaganda-8.0-Skateboard-Deck-_245325.jpg"
            });
            lista.Add(new ProductViewModel
            {
                Id = 2,
                Name = "b",
                Description = "b",
                Price = 20,
                Photo = "https://scene7.zumiez.com/is/image/zumiez/pdp_hero/Superior-Glow-Propaganda-8.0-Skateboard-Deck-_245325.jpg"
            });
            lista.Add(new ProductViewModel
            {
                Id = 3,
                Name = "c",
                Description = "c",
                Price = 30,
                Photo = "https://scene7.zumiez.com/is/image/zumiez/pdp_hero/Superior-Glow-Propaganda-8.0-Skateboard-Deck-_245325.jpg"
            });
            lista.Add(new ProductViewModel
            {
                Id = 4,
                Name = "d",
                Description = "d",
                Price = 40,
                Photo = "https://scene7.zumiez.com/is/image/zumiez/pdp_hero/Superior-Glow-Propaganda-8.0-Skateboard-Deck-_245325.jpg"
            });


            return Ok(lista);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductViewModel data)
        {


            return BadRequest();

            //return StatusCode(201);
        }
    }
}
