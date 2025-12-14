using System.Collections.Generic;
using System.Linq;
using ProdutosNetPoUi.Domain.Entities;
using ProdutosNetPoUi.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using ProdutosNetPoUi.Domain.Repositories;
using ProdutosNetPoUi.Infra.Contexts;

namespace ProdutosNetPoUi.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Produto aluno)
        {
            _context.Produto.Add(aluno);
            _context.SaveChanges();
        }

        public Produto GetByUser(string user)
        {
            return _context
            .Produto
            .FirstOrDefault(ProdutoQueries.GetByUser(user));
        }

        public IEnumerable<Produto> GetAll()
        {
            return _context.Produto.OrderBy(ProdutoQueries.WhereOrderBy());
        }

        public void Update(Produto produto)
        {
           _context.Entry(produto).State = EntityState.Modified;
           _context.SaveChanges();
        }
        public void Delete(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Deleted;
            _context.Produto.Remove(produto);
            _context.SaveChanges();
        }
    }
}