using ProdutosNetPoUi.Domain.Commands;
using ProdutosNetPoUi.Domain.Commands.Contracts;
using ProdutosNetPoUi.Domain.Entities;
using ProdutosNetPoUi.Domain.Handlers.Contracts;
using ProdutosNetPoUi.Domain.Repositories;
using Flunt.Notifications;
using ProdutosNetPoUi.Domain.Commands.ProdutoCommands;

namespace ProdutosNetPoUi.Domain.Handlers
{
    public class ProdutoHandler :
        Notifiable<Notification>,
        IHandler<CreateProdutoCommand>,
        IHandler<UpdateProdutoCommand>
    {
        private readonly IProdutoRepository _repository;
        public ProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateProdutoCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult(false, "Erro na criação do Produto!", command.Notifications);

            var produto = new Produto()
            {
                Descricao = command.Descricao,
                Preco = command.Preco,
                DataCadastro = DateTime.Now,
                Image = command.Image
            };

            _repository.Create(produto);

            return new CommandResult(true, "Produto salvo com sucesso!", produto);
        }

        public ICommandResult Handle(UpdateProdutoCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult(false, "Erro na atualização do produto!", command.Notifications);

            // Recupera o produto
            var produto = _repository.GetByUser(command.Id);
            produto.Descricao = command.Descricao;
            produto.Preco = command.Preco;

            _repository.Update(produto);

            return new CommandResult(true, "Produto atualizado com sucesso!", produto);
        }

        public ICommandResult Handle(DeleteProdutoCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult(false, "Erro na exclusão do Produto!", command.Notifications);

            // Recupera o produto
            var produto = _repository.GetByUser(command.Id);

            _repository.Delete(produto);

            return new CommandResult(true, "Produto salvo com sucesso!", produto);
        }
    }
}
