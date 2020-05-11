using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using SkateStore.Products.Domain.Commands.Handlers;
using SkateStore.Products.Domain.Commands.Inputs;
using SkateStore.Products.Domain.Repositories;
using SkateStore.Products.Infra.Data.Transactions;

namespace SkateStore.Products.Application.gRPC
{

    public class ProductsService : ProductsBuf.ProductsBufBase
    {
        private readonly ILogger<ProductsService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ProductHandler _productHandler;
        private readonly IUow _uow;

        public ProductsService(
            ILogger<ProductsService> logger,
            IProductRepository productRepository,
            ProductHandler productHandler,
            IUow uow)
        {
            _logger = logger;
            _productRepository = productRepository;
            _productHandler = productHandler;
            _uow = uow;
        }

        public override async Task<ProductsReply> Get(Empty request, ServerCallContext context)
        {

            var aa = await _productRepository.GetAsync();



            var lista = new List<ProductBuf>();
            lista.Add(new ProductBuf
            {
                Id = 1,
                Name = "a",
                Description = "a",
                Price = 10,
                Photo = "https://scene7.zumiez.com/is/image/zumiez/pdp_hero/Superior-Glow-Propaganda-8.0-Skateboard-Deck-_245325.jpg"
            });
            lista.Add(new ProductBuf
            {
                Id = 2,
                Name = "b",
                Description = "b",
                Price = 20,
                Photo = "https://scene7.zumiez.com/is/image/zumiez/pdp_hero/Superior-Glow-Propaganda-8.0-Skateboard-Deck-_245325.jpg"
            });
            lista.Add(new ProductBuf
            {
                Id = 3,
                Name = "c",
                Description = "c",
                Price = 30,
                Photo = "https://scene7.zumiez.com/is/image/zumiez/pdp_hero/Superior-Glow-Propaganda-8.0-Skateboard-Deck-_245325.jpg"
            });
            lista.Add(new ProductBuf
            {
                Id = 4,
                Name = "d",
                Description = "d",
                Price = 40,
                Photo = "https://scene7.zumiez.com/is/image/zumiez/pdp_hero/Superior-Glow-Propaganda-8.0-Skateboard-Deck-_245325.jpg"
            });

            var result = new ProductsReply();
            result.Products.AddRange(lista);

            return await Task.FromResult(result);
        }

        public override async Task<ResultReplay> Post(ProductBuf request, ServerCallContext context)
        {

            var command = new CreateProductCommandHandler(request.Name, request.Description, request.Price, request.Photo);
            _productHandler.Handle(command);

            if(_productHandler.Invalid)
                return await Task.FromResult(new ResultReplay
                {
                    StatusCode = 400
                });

            if(_uow.Commit() == 0)
                return await Task.FromResult(new ResultReplay
                {
                    StatusCode = 400
                });

            return await Task.FromResult(new ResultReplay { 
                StatusCode = 201
            });
        }
    }
}
