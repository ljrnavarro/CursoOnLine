using ProdutosNetPoUi.Domain.Commands.ProdutoCommands;

namespace ProdutosNetPoUi.Tests.CommandTests
{
    [TestClass]
    public class UpdateAlunoCommandTestes
    {

        [TestMethod]
        public void ValidCommand()
        {
            var command = new UpdateProdutoCommand("",0,"","1");
            command.Validate();
            Assert.AreEqual(command.IsValid, false);
        }

        [TestMethod]
        public void InvalidCommand()
        {
            var command = new UpdateProdutoCommand("Teste de produto",10,"","1");;
            command.Validate();
            Assert.AreEqual(command.IsValid, true);
        }

    }
}