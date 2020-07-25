using CursoOnline.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.EntityTests
{
    [TestClass]
    public class CartaoTests
    {

        [TestMethod]
        public void ValidEntity()
        {
            var cartao = new Cartao(){
                Numero = "00000000"
            };
            Assert.AreEqual(string.IsNullOrEmpty(cartao.Numero), false);

        }

        [TestMethod]
        public void InvalidEntity()
        {
             var cartao = new Cartao();
            Assert.AreEqual(string.IsNullOrEmpty(cartao.Numero), true);

        }
        
    }
}