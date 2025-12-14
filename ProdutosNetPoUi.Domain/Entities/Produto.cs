using System;
using System.Collections.Generic;

namespace ProdutosNetPoUi.Domain.Entities
{
    public class Produto : Base
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Image { get; set; }
    }
}