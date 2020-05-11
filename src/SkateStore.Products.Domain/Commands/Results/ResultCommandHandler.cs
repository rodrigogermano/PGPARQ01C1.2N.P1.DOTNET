namespace SkateStore.Products.Domain.Commands.Results
{
    public class ResultCommandHandler : ICommandResult
    {
        public ResultCommandHandler(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }
}
