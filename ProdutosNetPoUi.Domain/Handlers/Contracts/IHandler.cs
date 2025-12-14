using ProdutosNetPoUi.Domain.Commands.Contracts;

namespace ProdutosNetPoUi.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
       ICommandResult Handle(T command);
    }
}