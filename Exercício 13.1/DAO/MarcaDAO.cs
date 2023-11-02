using Exercício_13._1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Exercício_13._1.DAO
{
    public class MarcaDAO : PadraoDAO<MarcaViewModel>
    {
        public List<MarcaViewModel> ListaMarcas()
        {
            List<MarcaViewModel> lista = new List<MarcaViewModel>();
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemMarca", null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaMarca(registro));
            return lista;
        }

        private MarcaViewModel MontaMarca(DataRow registro)
        {
            MarcaViewModel c = new MarcaViewModel()
            {
                Id = Convert.ToInt32(registro["IdMarca"]),
                Descricao = registro["Descricao"].ToString()
            };
            return c;
        }

        protected override SqlParameter[] CriaParametros(MarcaViewModel model)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("IdMarca", model.Id),
                new SqlParameter("Descricao", model.Descricao)
            };
            return parametros;
        }

        protected override MarcaViewModel MontaModel(DataRow registro)
        {
            MarcaViewModel c = new MarcaViewModel()
            {
                Id = Convert.ToInt32(registro["IdMarca"]),
                Descricao = registro["Descricao"].ToString()
            };
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Marca";
        }
    }
}
