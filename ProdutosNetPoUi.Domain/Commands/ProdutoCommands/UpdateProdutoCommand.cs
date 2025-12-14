using System;
using System.Diagnostics.Contracts;
using ProdutosNetPoUi.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ProdutosNetPoUi.Domain.Commands.ProdutoCommands
{
    public class UpdateProdutoCommand : Notifiable<Notification>, ICommand
    {

        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Id { get; set; }
        public string image { get; set; }
        public UpdateProdutoCommand() { }

        public UpdateProdutoCommand(string descricao, decimal preco, string image, string id)
        {
            this.Descricao = descricao;
            this.Preco = preco;
            this.image = image;
            this.Id = id;
        }

        public void Validate()
        {
            AddNotifications(
               new Contract<Notification>()
               .Requires()
               .IsLowerThan(Descricao.Length, 20, "Descricao", "Descricao Inválida, necessário no mínimo 20 caracteres!")
               .IsGreaterThan(Preco, 0, "Preço precisa ser maior que zero.")
            );
        }

    }
}