using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.PagamentoCommands;
using CursoOnline.Domain.Commands.Contracts;
using CursoOnline.Domain.Repositories;
using Flunt.Notifications;
using CursoOnline.Domain.Handlers.Contracts;
using CursoOnline.Domain.Commands.CursoCommands;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Handlers
{
    public class CursoHandler:
    Notifiable,
    IHandler<CreateCursoCommand>
    {
        private readonly ICursoRepository _repository;

        public CursoHandler(ICursoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCursoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Erro na criação do Curso!", command.Notifications);

            var curso = new Curso()
            {
                Titulo = command.Titulo,
                Descricao = command.Descricao,
                Nivel = command.Nivel
            };

            _repository.Create(curso);

            return new CommandResult(true, "Curso cadastrado com Sucesso!", curso);
        }
    }
}