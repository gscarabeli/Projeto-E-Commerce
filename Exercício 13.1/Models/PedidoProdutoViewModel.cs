using System;

namespace Exercício_13._1.Models
{
    public class PedidoProdutoViewModel : PadraoViewModel
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
