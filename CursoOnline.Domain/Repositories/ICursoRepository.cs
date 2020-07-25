using System.Collections.Generic;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Repositories
{
    public interface ICursoRepository
    {
        void Create(Curso curso);
        void Update(Curso curso);
         IEnumerable<Curso> GetAll();
        
    }
}