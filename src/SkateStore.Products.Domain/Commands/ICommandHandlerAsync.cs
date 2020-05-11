using System.Threading.Tasks;

namespace SkateStore.Products.Domain.Commands
{
    public interface ICommandHandlerAsync<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
