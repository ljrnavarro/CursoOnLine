using System;
using System.Collections.Generic;
using System.Linq;
using ProdutosNetPoUi.Domain.Entities;
using ProdutosNetPoUi.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProdutosNetPoUi.Tests.QueryTestes
{
    [TestClass]
    public class ProdutoQueryTests
    {
        private List<Produto> _items;

        public ProdutoQueryTests()
        {
            _items = new List<Produto>();
            _items.Add(new Produto(){Descricao = "Teste Produto", Preco = 10, DataCadastro = DateTime.Now });
            _items.Add(new Produto() { Descricao = "Teste Produto 2", Preco = 20, DataCadastro = DateTime.Now });
        }

        [TestMethod]
        public void QueryUniqueUser()
        {
           var result = _items.AsQueryable().OrderBy(ProdutoQueries.WhereOrderBy());
           Assert.IsTrue(result.Count() == 2);
        }
        
    }
}