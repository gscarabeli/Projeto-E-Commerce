using Exercício_13._1.DAO;
using Exercício_13._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercício_13._1.Controllers
{
    public class CategoriaController : PadraoController<CategoriaViewModel>
    {
        public CategoriaController()
        {
            DAO = new CategoriaDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(CategoriaViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Descricao))
                ModelState.AddModelError("Descricao", "Preencha o nome.");
        }
    }
}
