using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.MatriculaCommands;
using CursoOnline.Domain.Commands.Contracts;
using CursoOnline.Domain.Handlers.Contracts;
using CursoOnline.Domain.Repositories;
using Flunt.Notifications;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Handlers
{
    public class MatriculaHandler :
    Notifiable,
    IHandler<CreateMatriculaCommand>
    {
        private readonly IMatriculaRepository _repository;

        public MatriculaHandler(IMatriculaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateMatriculaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Erro na criação da Matrícula!", command.Notifications);

            var matricula = new Matricula()
            {
                IdAluno = command.IdAluno,
                IdCurso = command.IdCurso,
                Data = command.Data
            };

            _repository.Create(matricula);   

            return new CommandResult(true, "Matrícula registrada com Sucesso!", matricula);
        }
    }
}