using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Infra.Contexts;
using CursoOnline.Domain.Queries;
using CursoOnline.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Domain.Infra.Repositories
{
    public class CartaoRepository : ICartaoRepository
    {
        private readonly DataContext _context;

        public CartaoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Cartao cartao)
        {
            _context.Cartao.Add(cartao);
            _context.SaveChanges();
        }

        public IEnumerable<Cartao> GetAll(int idAluno)
        {
            return _context.Cartao
            .Where(CartaoQueries.GetAll(idAluno));
        }

        public void Update(Cartao cartao)
        {
            _context.Entry(cartao).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}