using System;

namespace Exercício_13._1.Models
{
    public class PedidoViewModel : PadraoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string InformacoesTecnicas { get; set; }
        public int IdCategoria { get; set; }
        public double? Preco { get; set; }
        public int IdMarca { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCriacaoProduto { get; set; }
        public int IdArquivo { get; set; }
    }
}
