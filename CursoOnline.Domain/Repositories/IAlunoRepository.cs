using System.Collections.Generic;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Repositories
{
    public interface IAlunoRepository
    {
        void Create(Aluno aluno);
        void Update(Aluno aluno);
        Aluno GetByUser(string user);
        IEnumerable<Aluno> GetAll();
    }
}