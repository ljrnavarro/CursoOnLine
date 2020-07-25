using CursoOnline.Domain.Commands.CartaoCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateCartaoCommandTests
    {
        [TestMethod]
        public void ValidCommand()
        {
            var command = new CreateCartaoCommand(1,null,null,null);
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void InvalidCommand()
        {
            var command = new CreateCartaoCommand(1,"000000000000","01/2020","Amex");
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}
