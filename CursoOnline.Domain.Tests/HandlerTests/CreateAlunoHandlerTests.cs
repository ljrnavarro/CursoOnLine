using System;
using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.AlunoCommands;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.HandlerTests
{
     [TestClass]
    public class CreateAlunoHandlerTests
    {

        [TestMethod]
        public void InvalidHandler()
        {
            var command = new CreateAlunoCommand("","",DateTime.Now,"","");
            var handler = new AlunoHandler(new FakeAlunoRepository());
            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(result.Sucess, false);
        }

         [TestMethod]
        public void ValidHandler()
        {
            var command = new CreateAlunoCommand("Antonio Fracisco da Silva","00000000000",DateTime.Now,"email@email.com","0124");
            var handler = new AlunoHandler(new FakeAlunoRepository());
            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(result.Sucess, true);
        }
    }
}