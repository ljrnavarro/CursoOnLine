using System;
using CursoOnline.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoOnline.Domain.Commands.AlunoCommands
{
    public class UpdateAlunoCommand : Notifiable, ICommand
    {

        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Email {get; set;}
        public string RefUser { get; set; }
        public UpdateAlunoCommand() { }

         public UpdateAlunoCommand(string nome, string cpf, DateTime nascimento,string email, string refUser)
         {
                this.Nome = nome;
                this.CPF = cpf;
                this.Nascimento = nascimento;
                this.Email = email;
                this.RefUser = refUser;
         }


     public void Validate()
        {
           AddNotifications(
              new Contract()
              .Requires()
              .HasMinLen(Nome, 10,"Nome", "Nome Inválido, necessário no mínimo 20 caracteres!")
              .HasMaxLen(CPF,11 ,"CPF", "CPF Inválido") 
              .IsNotNullOrEmpty(Email,"Email", "Email requerido.")
              .IsNotNullOrEmpty(Nascimento.ToString(),"Nascimento", "Data de nascimento inválida")
           );
        }
        
    }
}