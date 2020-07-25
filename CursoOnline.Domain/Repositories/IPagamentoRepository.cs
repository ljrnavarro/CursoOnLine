using System.Collections.Generic;
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Repositories
{
    public interface IPagamentoRepository
    {
        void Create(Pagamento pagamento);
        void Update(Pagamento pagamento);
        IEnumerable<Pagamento> GetAll(int idAluno);
        
    }
}