using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Infra.Contexts;
using CursoOnline.Domain.Queries;
using CursoOnline.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Domain.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext _context;

        public AlunoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            _context.SaveChanges();
        }

        public Aluno GetByUser(string user)
        {
            return _context
            .Aluno
            .FirstOrDefault(AlunoQueries.GetByUser(user));
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _context.Aluno.Include("Cartoes")
            .OrderBy(AlunoQueries.WhereOrderBy());
        }

        public void Update(Aluno aluno)
        {
           _context.Entry(aluno).State = EntityState.Modified;
           _context.SaveChanges();
        }
    }
}