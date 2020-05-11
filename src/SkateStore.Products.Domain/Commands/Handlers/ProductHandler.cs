using FluentValidator;
using SkateStore.Products.Domain.Commands.Inputs;
using SkateStore.Products.Domain.Commands.Results;
using SkateStore.Products.Domain.Entities;
using SkateStore.Products.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace SkateStore.Products.Domain.Commands.Handlers
{
    public class ProductHandler : Notifiable, ICommandHandlerAsync<CreateProductCommandHandler>
    {
        private readonly IProductRepository _productRepository;
        public ProductHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }       

        public async Task<ICommandResult> Handle(CreateProductCommandHandler command)
        {
            var product = new Product(command.Name, command.Description, command.Price, command.Photo);
            AddNotifications(product.Notifications);
            
            if (Invalid)
                return null;

            _productRepository.Add(product);

            return new ResultCommandHandler(product.Id);
        }
    }
}
