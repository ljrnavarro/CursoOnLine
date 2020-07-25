using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Infra.Contexts;
using CursoOnline.Domain.Queries;
using CursoOnline.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Domain.Infra.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly DataContext _context;

        public CursoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Curso curso)
        {
           _context.Add(curso);
           _context.SaveChanges();
        }

        public IEnumerable<Curso> GetAll()
        {
           return  _context.Curso
            .Where(CursoQueries.GetAll());
        }

        public void Update(Curso curso)
        {
            _context.Entry(curso).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}