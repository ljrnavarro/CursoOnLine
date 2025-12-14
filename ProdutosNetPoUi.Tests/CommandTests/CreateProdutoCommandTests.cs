using ProdutosNetPoUi.Domain.Commands.ProdutoCommands;

namespace ProdutosNetPoUi.Tests.CommandTests
{
    [TestClass]
    public class CreateProdutoCommandTests
    {
        [TestMethod]
        public void ValidCommand()
        {
            var command = new CreateProdutoCommand("",0,DateTime.Now,"");
            command.Validate();
            Assert.AreEqual(command.IsValid, false);
        }

        [TestMethod]
        public void InvalidCommand()
        {
            var command = new CreateProdutoCommand("Teste Produto",10,DateTime.Now, "");
            command.Validate();
            Assert.AreEqual(command.IsValid, true);
        }
    }
}
