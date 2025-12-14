using System;
using ProdutosNetPoUi.Domain.Commands;
using ProdutosNetPoUi.Domain.Commands.ProdutoCommands;
using ProdutosNetPoUi.Domain.Handlers;
using ProdutosNetPoUi.Tests.FakeRepositories;

namespace ProdutosNetPoUi.Tests.HandlerTests
{
     [TestClass]
    public class CreateProdutoHandlerTests
    {

        [TestMethod]
        public void InvalidHandler()
        {
            var command = new CreateProdutoCommand("",10,DateTime.Now, "");
            var handler = new ProdutoHandler(new FakeProdutoRepository());
            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(result.Sucess, false);
        }

         [TestMethod]
        public void ValidHandler()
        {
            var command = new CreateProdutoCommand("Teste Produto",10,DateTime.Now,"");
            var handler = new ProdutoHandler(new FakeProdutoRepository());
            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(result.Sucess, true);
        }
    }
}