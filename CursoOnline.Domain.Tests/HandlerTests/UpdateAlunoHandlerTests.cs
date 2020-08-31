using System;
using System.Collections.Generic;
using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.AlunoCommands;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.HandlerTests
{
     [TestClass]
    public class UpdateAlunoHandlerTests
    {

        [TestMethod]
        public void InvalidHandler()
        {
            var command = new UpdateAlunoCommand("","",DateTime.Now,"","");
            var handler = new AlunoHandler(new FakeAlunoRepository());
            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(result.Sucess, false);
        }

         [TestMethod]
        public void ValidHandler()
        {
            //repository
            List<Aluno> listFakeAlunos = new List<Aluno>();
            listFakeAlunos.Add(
             new Aluno(){
                Nome = "Antonio Fracisco da Silva",
                CPF = "00000000000",
                Nascimento = DateTime.Now,
                Email = "email@email.com",
                RefUser = "01234"
            });
            //update Aluno
            var commandUpdate = new UpdateAlunoCommand("Antonio Fracisco da Silva Segundo","00000000000",DateTime.Now,"email@email.com","01234");
            var handler = new AlunoHandler(new FakeAlunoRepository(listFakeAlunos));
            var resultUpdate = (CommandResult)handler.Handle(commandUpdate);
            Assert.AreEqual(resultUpdate.Sucess, true);
        }
    }
}