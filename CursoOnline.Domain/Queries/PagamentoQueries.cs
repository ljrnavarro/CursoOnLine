using System;
using System.Linq.Expressions;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Queries
{
    public class PagamentoQueries
    {
         public static Expression<Func<Pagamento, bool>> GetAll(int idAluno)
        {
            return x => x.idAluno == idAluno;
        }
        
    }
}