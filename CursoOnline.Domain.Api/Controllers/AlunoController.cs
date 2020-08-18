using System.Collections.Generic;
using System.Linq;
using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.AlunoCommands;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Aluno")]
    [Authorize]
    public class AlunoController : ControllerBase
    {

        /// <summary>
        /// Cadastra um novo aluno junto com o token da google
        /// </summary>
        /// <param name="handler">Handle de entrada</param>
        /// <param name="command">Comand de entrada</param>
        /// <returns>
        /// <CommandResult>
        ///  <Sucess>Indica se (S)Sucesso e (F)Falha</Sucess>
        ///  <Msg>Retorno da operação</Msg>
        ///  <Data>Objeto da transação</Data>
        /// </CommandResult>
        /// </returns>
        [Route("")]
        [HttpPost]
        public CommandResult Create(
            [FromBody]CreateAlunoCommand command,
            [FromServices]AlunoHandler handler
        )
        {
            //Gravando o usuário token da google
           // command.RefUser = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (CommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Recebe uma lista de Alunos
        /// </summary>
        /// <param name="repository">repositório de pesquisa</param>
        [Route("")]
        [HttpGet]
        public IEnumerable<Aluno> GetAll(
            [FromServices]IAlunoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAll();
        }

        /// <summary>
        /// Recebe um  Aluno filtrado pelo usuário ID da Google
        /// </summary>
        /// <param name="user">usuário ID da Google</param>
        /// <param name="repository">repositório de pesquisa</param>
        [Route("{user}")]
        [HttpGet]
        public Aluno GetAllByUser(string user,
            [FromServices]IAlunoRepository repository
        )
        {
            return repository.GetByUser(user);
        }
    }
}