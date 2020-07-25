using System;
using System.Linq.Expressions;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Queries
{
    public class CartaoQueries
    {
        public static Expression<Func<Cartao, bool>> GetAll(int idAluno)
        {
            return x => x.IdAluno == idAluno;
        }
    }
}