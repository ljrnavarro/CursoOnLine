using System;
using CursoOnline.Domain.Commands.Contracts;
using CursoOnline.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoOnline.Domain.Commands.MatriculaCommands
{
    public class CreateMatriculaCommand : Notifiable,ICommand  
    {
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }
        public DateTime Data { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Curso Curso { get; set; }
        public CreateMatriculaCommand()
        {
        }

        public CreateMatriculaCommand(int idAluno, int idCurso, DateTime data)
        {
            this.IdAluno = idAluno;
            this.IdCurso = idCurso;
            this.Data = data;

        }

       
        public void Validate()
        {
           AddNotifications(
              new Contract()
              .Requires()
              .IsNotNullOrEmpty(Data.ToString(),"Data", "Data da Matricula Invalida")
           );
        }
    }
}