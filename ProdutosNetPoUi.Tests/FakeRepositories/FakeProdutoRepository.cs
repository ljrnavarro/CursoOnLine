using System.Collections.Generic;
using ProdutosNetPoUi.Domain.Entities;
using ProdutosNetPoUi.Domain.Repositories;
using System.Linq;

namespace ProdutosNetPoUi.Tests.FakeRepositories
{
    public class FakeProdutoRepository : IProdutoRepository
    {

        private readonly IEnumerable<Produto> _context;

        public FakeProdutoRepository(IEnumerable<Produto> context)
        {
            _context = context;
        }

        public FakeProdutoRepository()
        {
        }

        public void Create(Produto produto)
        {
        }

        public Produto GetByUser(string id)
        {
             return (from e in _context where e.Id.ToString() == id select e).SingleOrDefault();
        }

        public IEnumerable<Produto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Produto produto)
        {
        }
    }
}