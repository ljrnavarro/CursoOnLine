using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Infra.Contexts;
using CursoOnline.Domain.Queries;
using CursoOnline.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Domain.Infra.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly DataContext _context;

        public PagamentoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Pagamento pagamento)
        {
            _context.Pagamento.Add(pagamento);
            _context.SaveChanges();
        }

        public IEnumerable<Pagamento> GetAll(int idAluno)
        {
           return _context.Pagamento
           .Where(PagamentoQueries.GetAll(idAluno));
        }

        public void Update(Pagamento pagamento)
        {
            _context.Entry(pagamento).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}