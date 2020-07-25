using System.Collections.Generic;
using CursoOnline.Domain.Commands;
using CursoOnline.Domain.Commands.PagamentoCommands;
using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Handlers;
using CursoOnline.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Api.Controllers
{
    [ApiController]
    [Route("v1/Pagamento")]
    [Authorize]
    public class PagamentoController : ControllerBase
    {
      
        /// <summary>
        /// Cadastra um novo Pagamento
        /// </summary>
        /// <param name="command">Comand de entrada</param>
        /// <param name="handler">Handle de entrada</param>
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
            [FromBody]CreatePagamentoCommand command,
            [FromServices]PagamentoHandler handler
        )
        {
           return (CommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Retorna Lista de Pagamentos
        /// </summary>
        /// <param name="id">id do aluno</param>
        /// <param name="repository">repositorio de pagamentos</param>
        [Route("Aluno/{id}")]
        [HttpGet]
        public IEnumerable<Pagamento> GetAll(int id,
            [FromServices]IPagamentoRepository repository
        )
        {
           return repository.GetAll(id);
        }
    }
}