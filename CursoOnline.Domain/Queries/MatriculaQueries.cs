using System;
using System.Linq.Expressions;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Queries
{
    public class MatriculaQueries
    {
        public static Expression<Func<Matricula, bool>> GetAll(int idAluno)
        {
            return x => x.IdAluno == idAluno;
        }
        
    }
}