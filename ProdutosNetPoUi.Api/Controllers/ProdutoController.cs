using System.Collections.Generic;
using System.Linq;
using ProdutosNetPoUi.Domain.Commands;
using ProdutosNetPoUi.Domain.Entities;
using ProdutosNetPoUi.Domain.Handlers;
using ProdutosNetPoUi.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdutosNetPoUi.Domain.Commands.ProdutoCommands;

namespace ProdutosNetPoUi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Produto")]
   // [Authorize]
    public class ProdutoController : ControllerBase
    {

        /// <summary>
        /// Cadastra um novo produto
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
            [FromBody] CreateProdutoCommand command,
            [FromServices] ProdutoHandler handler
        )
        {
            return (CommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Recebe uma lista de Produtos
        /// </summary>
        /// <param name="repository">repositório de pesquisa</param>
        [Route("")]
        [HttpGet]
        public IEnumerable<Produto> GetAll(
            [FromServices] IProdutoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAll();
        }

        /// <summary>
        /// Recebe um Produto filtrado pelo usuário
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="repository">repositório de pesquisa</param>
        [Route("{id}")]
        [HttpGet]
        public Produto GetAllByUser(string id,
            [FromServices] IProdutoRepository repository
        )
        {
            return repository.GetByUser(id);
        }


        /// <summary>
        /// Atualiza dados do produto
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns></returns>         
        [Route("")]
        [HttpPut]
        public CommandResult Update(
            [FromBody] UpdateProdutoCommand command,
            [FromServices] ProdutoHandler handler
        )
        {
            return (CommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="handler"></param>
        /// <returns></returns>         
        [Route("{id}")]
        [HttpDelete]
        public CommandResult Delete(
            string id,
            [FromServices] ProdutoHandler handler
        )
        {
            return (CommandResult)handler.Handle(new DeleteProdutoCommand(id));
        }
    }
}