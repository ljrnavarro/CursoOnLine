using CursoOnline.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.EntityTests
{
    [TestClass]
    public class AlunoTests
    {

        [TestMethod]
        public void ValidEntity()
        {
            var aluno = new Aluno(){
                Nome = "Aluno Teste"
            };
            Assert.AreEqual(string.IsNullOrEmpty(aluno.Nome), false);

        }

        [TestMethod]
        public void InvalidEntity()
        {
            var aluno = new Aluno();
            Assert.AreEqual(string.IsNullOrEmpty(aluno.Nome), true);

        }
        
    }
}