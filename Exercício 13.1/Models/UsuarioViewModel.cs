using System;

namespace Exercício_13._1.Models
{
    public class UsuarioViewModel : PadraoViewModel
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
