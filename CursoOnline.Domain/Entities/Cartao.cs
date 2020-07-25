namespace CursoOnline.Domain.Entities
{
    public class Cartao : Base
    {
        public string Numero { get; set; }
        public string Validade { get; set; }
        public string Bandeira { get; set; }
        public int IdAluno { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}