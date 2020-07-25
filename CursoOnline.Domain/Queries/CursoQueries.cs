using System;
using System.Linq.Expressions;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Queries
{
    public class CursoQueries
    {
        public static Expression<Func<Curso, bool>> GetAll()
        {
            return x => x.Id > 0;
        }

    }
}