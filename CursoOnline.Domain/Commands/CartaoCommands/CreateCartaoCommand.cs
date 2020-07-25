using CursoOnline.Domain.Commands.Contracts;
using CursoOnline.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoOnline.Domain.Commands.CartaoCommands
{
    public class CreateCartaoCommand : Notifiable, ICommand
    {
        public int IdAluno { get; set; }
        public string Numero { get; set; }
        public string Validade { get; set; }
        public string Bandeira { get; set; }
        public virtual Aluno Aluno { get; set; }

        public CreateCartaoCommand()
        {
        }
        public CreateCartaoCommand(int idAluno, string numero, string validade, string bandeira)
        {
            this.IdAluno = idAluno;
            this.Numero = numero;
            this.Validade = validade;
            this.Bandeira = bandeira;
        }

         public void Validate()
        {
           AddNotifications(
              new Contract()
              .Requires()
              .IsNotNullOrEmpty(Numero,"Numero", "Nome cartão, necessário no mínimo 20 caracteres!")
              .IsNotNullOrEmpty(Bandeira,"Bandeira", "Bandeira") 
           );
        }
    }
}