using System;
using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.MatriculaCommands;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Infra.Repositories;
using CursoOnline.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Api.Controllers
{
    [ApiController]
    [Route("v1/Matricula")]
    public class MatriculaController : ControllerBase
    {
        /// <summary>
        /// Cadastra nova matricula
        /// </summary>
        /// <param name="command">Comand de entrada</param>
        /// <param name="handler">Handle de entrada</param>
        /// <param name="pagrepository">repositorio de pagamento</param>
        /// /// /// <returns>
        /// <CommandResult>
        ///  <Sucess>Indica se (S)Sucesso e (F)Falha</Sucess>
        ///  <Msg>Retorno da operação</Msg>
        ///  <Data>Objeto da transação</Data>
        /// </CommandResult>
        /// </returns>
        [Route("")]
        [HttpPost]
        [Authorize]
        public CommandResult Create(
            [FromBody]CreateMatriculaCommand command,
            [FromServices]MatriculaHandler handler,
            [FromServices]IPagamentoRepository pagrepository
        )
        {
            if (pagrepository.GetAll(command.IdAluno).Count() == 0)
                return new CommandResult()
                {
                    Data = command,
                    Message = "Não há pagamentos para o aluno",
                    Sucess = false
                };

            return (CommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Recebe matricula por aluno
        /// </summary>
        /// <param name="id">id do aluno</param>
        /// <param name="repository">repositorio de matriculas</param>
        [Route("Aluno/{id}")]
        [HttpGet]
        public IEnumerable<Matricula> GetAll(int id,
            [FromServices]IMatriculaRepository repository
        )
        {
            return repository.GetAll(id);
        }
    }
}