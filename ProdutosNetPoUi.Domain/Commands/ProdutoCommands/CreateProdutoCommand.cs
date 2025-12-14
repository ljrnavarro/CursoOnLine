using System;
using ProdutosNetPoUi.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ProdutosNetPoUi.Domain.Commands.ProdutoCommands
{
    public class CreateProdutoCommand : Notifiable<Notification>, ICommand
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Image {get; set;}
        public CreateProdutoCommand()
        {
        }
        
        public CreateProdutoCommand(string descricao, decimal preco, DateTime dataCadastro,string image)
        {
            this.Descricao = descricao;
            this.Preco = preco;
            this.DataCadastro = dataCadastro;
            this.Image = image;

        }

        public void Validate()
        {
            AddNotifications(
               new Contract<Notification>()
               .Requires()
             //  .IsLowerThan(Descricao.Length, 20, "Descrição", "Descrição Inválida, necessário no mínimo 20 caracteres!")
               .IsNotNull(Preco,"Preco", "Preço obrigatório")
           );
        }
    }
}