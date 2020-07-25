using System;
using CursoOnline.Domain.Commands.Contracts;
using CursoOnline.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoOnline.Domain.Commands.PagamentoCommands
{
    public class CreatePagamentoCommand : Notifiable, ICommand
    {
        public int idAluno { get; set; }
        public int idCartao { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Cartao Cartao { get; set; }
        public CreatePagamentoCommand()
        {
        }

        public CreatePagamentoCommand(int idAluno, int idCartao, DateTime data, Decimal valor)
        {
            this.idAluno = idAluno;
            this.idCartao = idCartao;
            this.Data = data;
            this.Valor = valor;

        }

       public void Validate()
        {
           AddNotifications(
              new Contract()
              .Requires()
              .IsNotNullOrEmpty(Data.ToString(),"Data", "Data pagamento Invalida")
           );
        }
    }
}