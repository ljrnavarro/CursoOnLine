using System;
using System.Linq.Expressions;
using ProdutosNetPoUi.Domain.Entities;

namespace ProdutosNetPoUi.Domain.Queries
{
    public static class ProdutoQueries
    {
        public static Expression<Func<Produto, bool>> GetByUser(string id)
        {
            return x => x.Id.ToString() == id;
        }

        public static Expression<Func<Produto, string>> WhereOrderBy()
        {
            return x => x.Descricao;
        }
    }
}