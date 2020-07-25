using System;
using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.CartaoCommands;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.HandlerTests
{
     [TestClass]
    public class CreateCartaoHandlerTests
    {

        [TestMethod]
        public void InvalidHandler()
        {
            var command = new CreateCartaoCommand(1,null,null,null);
            var handler = new CartaoHandler(new FakeCartaoRepository());
            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(result.Sucess, false);
        }

         [TestMethod]
        public void ValidHandler()
        {
            var command = new CreateCartaoCommand(1,"000000000000","01/2020","Amex");
            var handler = new CartaoHandler(new FakeCartaoRepository());
            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(result.Sucess, true);
        }
    }
}