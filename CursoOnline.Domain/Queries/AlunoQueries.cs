using System;
using System.Linq.Expressions;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Queries
{
    public static class AlunoQueries
    {
        public static Expression<Func<Aluno, bool>> GetByUser(string user)
        {
            return x => x.RefUser == user;
        }

        public static Expression<Func<Aluno, string>> WhereOrderBy()
        {
            return x => x.Nome;
        }
    }
}