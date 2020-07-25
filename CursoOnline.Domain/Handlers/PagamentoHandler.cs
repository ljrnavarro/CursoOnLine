using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.PagamentoCommands;
using CursoOnline.Domain.Commands.Contracts;
using CursoOnline.Domain.Repositories;
using Flunt.Notifications;
using CursoOnline.Domain.Handlers.Contracts;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Handlers
{
    public class PagamentoHandler:
    Notifiable,
    IHandler<CreatePagamentoCommand>
    {
        private readonly IPagamentoRepository _repository;

        public PagamentoHandler(IPagamentoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePagamentoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Erro na criação do Pagamento!", command.Notifications);

            var pagamento = new Pagamento()
            {
                idAluno = command.idAluno,
                idCartao = command.idCartao,
                Data = command.Data,
                Valor = command.Valor
            };

            _repository.Create(pagamento);

            return new CommandResult(true, "Sucesso", pagamento);
        }
    }
}