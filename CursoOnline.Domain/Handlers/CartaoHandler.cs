using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.CartaoCommands;
using CursoOnline.Domain.Commands.Contracts;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Handlers.Contracts;
using CursoOnline.Domain.Repositories;
using Flunt.Notifications;

namespace CursoOnline.Domain.Handlers
{
    public class CartaoHandler:
    Notifiable,
    IHandler<CreateCartaoCommand>
    {

        private readonly ICartaoRepository _repository;

        public CartaoHandler(ICartaoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCartaoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Erro na criação do cartão!", command.Notifications);

            var cartao = new Cartao()
            {
                IdAluno = command.IdAluno,
                Bandeira = command.Bandeira,
                Numero = command.Numero,
                Validade = command.Validade
            }; 

            _repository.Create(cartao);
            
            return new CommandResult(true, "Cartão registrado com Sucesso", cartao);
        }
    }
}