using ProdutosNetPoUi.Domain.Commands;
using ProdutosNetPoUi.Domain.Commands.ProdutoCommands;
using ProdutosNetPoUi.Domain.Entities;
using ProdutosNetPoUi.Domain.Handlers;
using ProdutosNetPoUi.Tests.FakeRepositories;

namespace ProdutosNetPoUi.Tests.HandlerTests
{
    [TestClass]
    public class UpdateProdutoHandlerTests
    {

        [TestMethod]
        public void InvalidHandler()
        {
            var command = new UpdateProdutoCommand("",10,"", "1");
            var handler = new ProdutoHandler(new FakeProdutoRepository());
            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(result.Sucess, false);
        }

         [TestMethod]
        public void ValidHandler()
        {
            //repository
            List<Produto> listFakeProdutos = new List<Produto>();
            listFakeProdutos.Add(
             new Produto(){
                Descricao = "Teste produto",
                Preco = 10,
                DataCadastro = DateTime.Now,
                Image = ""
            });
            //update Aluno
            var commandUpdate = new UpdateProdutoCommand("Teste produto",10,"email@email.com","1");
            var handler = new ProdutoHandler(new FakeProdutoRepository(listFakeProdutos));
            var resultUpdate = (CommandResult)handler.Handle(commandUpdate);
            Assert.AreEqual(resultUpdate.Sucess, true);
        }
    }
}