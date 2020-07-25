using CursoOnline.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoOnline.Domain.Commands.CursoCommands
{
    public class CreateCursoCommand : Notifiable, ICommand
    {
        public string Titulo {get; set;}
        public string Descricao { get; set; }
        public string Nivel { get; set; }
        public CreateCursoCommand()
        {
        }

        public CreateCursoCommand(string Titulo, string Descricao, string Nivel)
        {
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Nivel = Nivel;
        }
        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotNullOrEmpty(Descricao, "Descricao", "Descrição requerida")
               .HasMaxLen(Descricao,300 ,"Descrição", "Excede o tamando máximo para o campo [Descricão]")
               .HasMaxLen(Titulo, 200,"Título", "Excede o tamando máximo para o campo [Título]")
            );
        }
    }
}