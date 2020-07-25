using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Infra.Contexts;
using CursoOnline.Domain.Queries;
using CursoOnline.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Domain.Infra.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly DataContext _context;

        public MatriculaRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            _context.SaveChanges();
        }

        public IEnumerable<Matricula> GetAll(int idAluno)
        {
           return _context.Matricula
           .Where(MatriculaQueries.GetAll(idAluno));
        }

        public void Update(Matricula matricula)
        {
            _context.Entry(matricula).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}