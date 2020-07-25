using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.AlunoCommands;
using CursoOnline.Domain.Commands.Contracts;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Handlers.Contracts;
using CursoOnline.Domain.Repositories;
using Flunt.Notifications;

namespace CursoOnline.Domain.Handlers
{
    public class AlunoHandler :
        Notifiable,
        IHandler<CreateAlunoCommand>
    {
        private readonly IAlunoRepository _repository;
        public AlunoHandler(IAlunoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateAlunoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Erro na criação do aluno!", command.Notifications);
            
            var aluno = new Aluno()
            {
                Nome = command.Nome,
                CPF = command.CPF,
                Email = command.Email,
                Nascimento = command.Nascimento,
                RefUser = command.RefUser
            };

            _repository.Create(aluno);
            
            return new CommandResult(true, "Aluno salvo com sucesso!", aluno);
        }
    }
}
