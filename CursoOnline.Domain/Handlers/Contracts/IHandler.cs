using CursoOnline.Domain.Commands.Contracts;

namespace CursoOnline.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
       ICommandResult Handle(T command);
    }
}