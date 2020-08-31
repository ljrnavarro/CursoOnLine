using System.Collections.Generic;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Repositories;
using System.Linq;

namespace CursoOnline.Domain.Tests.FakeRepositories
{
    public class FakeAlunoRepository : IAlunoRepository
    {

        private readonly IEnumerable<Aluno> _context;

        public FakeAlunoRepository(IEnumerable<Aluno> context)
        {
            _context = context;
        }

        public FakeAlunoRepository()
        {
        }

        public void Create(Aluno aluno)
        {
        }

        public Aluno GetByUser(string user)
        {
             return (from e in _context where e.RefUser == user select e).SingleOrDefault();
        }

        public IEnumerable<Aluno> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Aluno aluno)
        {
        }
    }
}