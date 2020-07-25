using System;
using System.Collections.Generic;

namespace CursoOnline.Domain.Entities
{
    public class Aluno : Base
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Email {get; set;}
        public string RefUser { get; set; }
        public virtual ICollection<Cartao> Cartoes {get; set;}
    }
}