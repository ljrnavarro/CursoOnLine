using System.Collections.Generic;
using ProdutosNetPoUi.Domain.Entities;

namespace ProdutosNetPoUi.Domain.Repositories
{
    public interface IProdutoRepository
    {
        void Create(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        Produto GetByUser(string id);
        IEnumerable<Produto> GetAll();
    }
}