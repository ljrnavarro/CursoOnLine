using System;
using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CursoOnline.Domain.Tests.QueryTestes
{
    [TestClass]
    public class AlunoQueryTests
    {
        private List<Aluno> _items;

        public AlunoQueryTests()
        {
            _items = new List<Aluno>();
            _items.Add(new Aluno(){Nome = "João", CPF = "12121221", Email = "joao@mail.com", Nascimento = DateTime.Now });
            _items.Add(new Aluno(){Nome = "Maria", CPF = "5555555", Email = "maria@mail.com", Nascimento = DateTime.Now });
        }

        [TestMethod]
        public void QueryUniqueUser()
        {
           var result = _items.AsQueryable().OrderBy(AlunoQueries.WhereOrderBy());
           Assert.IsTrue(result.Count() == 2);
        }
        
    }
}