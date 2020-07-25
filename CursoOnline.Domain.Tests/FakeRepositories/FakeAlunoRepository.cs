using System.Collections.Generic;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Repositories;

namespace CursoOnline.Domain.Tests.FakeRepositories
{
    public class FakeAlunoRepository : IAlunoRepository
    {
        public void Create(Aluno aluno)
        {
        }

        public Aluno GetByUser(string user)
        {
            throw new System.NotImplementedException();
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