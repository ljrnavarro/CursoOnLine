using System;
using ProdutosNetPoUi.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ProdutosNetPoUi.Domain.Commands.ProdutoCommands
{
    public class DeleteProdutoCommand : Notifiable<Notification>, ICommand
    {
        public string Id { get; set; }
       
        public DeleteProdutoCommand()
        {
        }
        
        public DeleteProdutoCommand(string id)
        {
            this.Id = id;
        }

        public void Validate()
        {
            AddNotifications(
               new Contract<Notification>()
               .Requires()
               .IsNotNull(Id,"Id", "Identificador obrigatório")
           );
        }
    }
}