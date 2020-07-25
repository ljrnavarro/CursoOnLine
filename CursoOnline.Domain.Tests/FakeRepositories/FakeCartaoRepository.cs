using System.Collections.Generic;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Repositories;

namespace CursoOnline.Domain.Tests.FakeRepositories
{
    public class FakeCartaoRepository : ICartaoRepository
    {
        public void Create(Cartao cartao)
        {
        }

        public IEnumerable<Cartao> GetAll(int idAluno)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Cartao cartao)
        {
        }
    }
}