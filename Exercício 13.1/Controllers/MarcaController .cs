using Exercício_13._1.DAO;
using Exercício_13._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercício_13._1.Controllers
{
    public class MarcaController : PadraoController<MarcaViewModel>
    {
        public MarcaController()
        {
            DAO = new MarcaDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(MarcaViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Descricao))
                ModelState.AddModelError("Descricao", "Preencha o nome.");
        }
    }
}
