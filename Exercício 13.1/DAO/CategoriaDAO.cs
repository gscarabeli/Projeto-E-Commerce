using Exercício_13._1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Exercício_13._1.DAO
{
    public class CategoriaDAO : PadraoDAO<CategoriaViewModel>
    {
        public List<CategoriaViewModel> ListaCategorias()
        {
            List<CategoriaViewModel> lista = new List<CategoriaViewModel>();
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemCategorias", null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaCategoria(registro));
            return lista;
        }

        private CategoriaViewModel MontaCategoria(DataRow registro)
        {
            CategoriaViewModel c = new CategoriaViewModel()
            {
                Id = Convert.ToInt32(registro["IdCategoria"]),
                Descricao = registro["Descricao"].ToString()
            };
            return c;
        }

        protected override SqlParameter[] CriaParametros(CategoriaViewModel model)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("IdCategoria", model.Id),
                new SqlParameter("Descricao", model.Descricao)
            };
            return parametros;
        }

        protected override CategoriaViewModel MontaModel(DataRow registro)
        {
            CategoriaViewModel c = new CategoriaViewModel()
            {
                Id = Convert.ToInt32(registro["IdCategoria"]),
                Descricao = registro["Descricao"].ToString()
            };
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Categoria";
        }
    }
}
