using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.QueryTestes
{
    [TestClass]
    public class CartaoQueryTests
    {

        private List<Cartao> _items;

        public CartaoQueryTests()
        {
            _items = new List<Cartao>();
            _items.Add(new Cartao() { IdAluno = 1, Bandeira = "Amex", Numero = "123456789", Validade = "02/26" });
            _items.Add(new Cartao() { IdAluno = 1, Bandeira = "Visa", Numero = "4567890123", Validade = "02/26" });
            _items.Add(new Cartao() { IdAluno = 2, Bandeira = "Visa", Numero = "000000000", Validade = "02/26" });
        }

        [TestMethod]
        public void QueryCartaoByAluno()
        {
            var result = _items.AsQueryable().Where(CartaoQueries.GetAll(1));
            Assert.IsTrue(result.Count() == 2);
        }

    }
}