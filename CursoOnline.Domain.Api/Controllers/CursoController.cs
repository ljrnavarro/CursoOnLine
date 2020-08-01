using System.Collections.Generic;
using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.CursoCommands;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CursoOnline.Api.Controllers
{
    
    [ApiController]
    [Route("v1/Curso")]
    [Authorize]
    public class CursoController : ControllerBase
    {
        /// <summary>
        /// Cadastra um novo Curso
        /// </summary>
        /// <param name="command">Comand de entrada</param>
        /// <param name="handler">Handle de entrada</param>
        /// /// /// <returns>
        /// <CommandResult>
        ///  <Sucess>Indica se (S)Sucesso e (F)Falha</Sucess>
        ///  <Msg>Retorno da operação</Msg>
        ///  <Data>Objeto da transação</Data>
        /// </CommandResult>
        /// </returns>
        [Route("")]
        [HttpPost]
        public CommandResult Create(
            [FromBody]CreateCursoCommand command,
            [FromServices]CursoHandler handler
        )
        {
            return (CommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Retorna lista de cartões
        /// </summary>
        
        [Route("")]
        [HttpGet]
        public IEnumerable<Curso> GetAll(
            [FromServices]ICursoRepository repository
        )
        {
            Thread.Sleep(4000);
            return repository.GetAll();
        }
    }
}