using System;

namespace CursoOnline.Domain.Entities
{
    public class Pagamento : Base
    {
        public int idAluno { get; set; }
        public int idCartao { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public virtual Aluno Aluno {get; set;}
        public virtual Cartao Cartao {get; set;}
    }
}