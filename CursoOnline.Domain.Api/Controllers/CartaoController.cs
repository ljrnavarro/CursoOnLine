using System.Collections.Generic;
using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.CartaoCommands;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Api.Controllers
{
    [ApiController]
    [Route("v1/Cartao")]
    [Authorize]
    public class CartaoController : ControllerBase
    {
        /// <summary>
        /// Cadastra um novo Cartao de um aluno
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
            [FromBody]CreateCartaoCommand command,
            [FromServices]CartaoHandler handler
        )
        {
            return (CommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Retorna lista de cartões de um aluno
        /// </summary>
        /// <param name="id">id do aluno</param>
        /// <param name="repository">referencia ao repositorio</param>
        /// <returns>
        /// </returns>
        [Route("Aluno/{id}")]
        [HttpGet]
        public IEnumerable<Cartao> GetAll(int id,
            [FromServices]ICartaoRepository repository
        )
        {
            return repository.GetAll(id);
        }
    }
}