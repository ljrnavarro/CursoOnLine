using System.Collections.Generic;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Repositories
{
    public interface IMatriculaRepository
    {
        void Create(Matricula matricula);
        void Update(Matricula matricula);
        IEnumerable<Matricula> GetAll(int idAluno);
    }
}       