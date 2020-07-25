using CursoOnline.Domain.Commands.AlunoCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CursoOnline.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateAlunoCommandTests
    {
        [TestMethod]
        public void ValidCommand()
        {
            var command = new CreateAlunoCommand("","",DateTime.Now,"","");
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void InvalidCommand()
        {
            var command = new CreateAlunoCommand("Antonio Fracisco da Silva","00000000000",DateTime.Now,"email@email.com","0124");
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}
