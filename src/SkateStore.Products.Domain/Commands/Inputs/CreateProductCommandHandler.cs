namespace SkateStore.Products.Domain.Commands.Inputs
{
    public class CreateProductCommandHandler : ICommand
    {
        public CreateProductCommandHandler()
        {

        }
        public CreateProductCommandHandler(string name, string description, decimal price, string photo)
        {
            Name = name;
            Description = description;
            Price = price;
            Photo = photo;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
    }
}
