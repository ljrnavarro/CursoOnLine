using System;
using CursoOnline.Domain.Commands.AlunoCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.CommandTests
{
    [TestClass]
    public class UpdateAlunoCommandTestes
    {

        [TestMethod]
        public void ValidCommand()
        {
            var command = new UpdateAlunoCommand("","",DateTime.Now,"","");
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void InvalidCommand()
        {
            var command = new UpdateAlunoCommand("Antonio Fracisco da Silva","00000000000",DateTime.Now,"email@email.com","0124");;
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }

    }
}