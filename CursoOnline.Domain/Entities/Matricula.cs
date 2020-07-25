using System;

namespace CursoOnline.Domain.Entities
{
    public class Matricula : Base
    {
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }
        public DateTime Data { get; set; }
        public virtual Aluno Aluno {get; set;}
        public virtual Curso Curso {get; set;}
    }
}