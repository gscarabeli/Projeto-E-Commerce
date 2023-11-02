using System;

namespace Exercício_13._1.Models
{
    public class ArquivoViewModel : PadraoViewModel
    {
        public byte[] Arquivo { get; set; }
        public string Descricao { get; set; }
    }
}
