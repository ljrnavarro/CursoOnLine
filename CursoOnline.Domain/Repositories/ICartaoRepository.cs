using System.Collections.Generic;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Repositories
{
    public interface ICartaoRepository
    {
        void Create(Cartao cartao);
        void Update(Cartao cartao);
         IEnumerable<Cartao> GetAll(int idAluno);
    }
}