using ProdutosNetPoUi.Domain.Commands.Contracts;

namespace ProdutosNetPoUi.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public CommandResult()
        {
        }

        public CommandResult(bool sucess, string message, object data)
        {
            this.Sucess = sucess;
            this.Message = message;
            this.Data = data;
        }

    }
}