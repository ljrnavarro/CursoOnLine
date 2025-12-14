using ProdutosNetPoUi.Domain.Entities;

namespace ProdutosNetPoUi.Tests.EntityTests
{
    [TestClass]
    public class ProdutoTests
    {

        [TestMethod]
        public void ValidEntity()
        {
            var produto = new Produto(){
                Descricao = "Produto Teste"
            };
            Assert.AreEqual(string.IsNullOrEmpty(produto.Descricao), false);

        }

        [TestMethod]
        public void InvalidEntity()
        {
            var produto = new Produto();
            Assert.AreEqual(string.IsNullOrEmpty(produto.Descricao), true);

        }
        
    }
}