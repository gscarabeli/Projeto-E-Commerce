using Exercício_13._1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Exercício_13._1.DAO
{
    public class ProdutoDAO : PadraoDAO<ProdutoViewModel>
    {
        protected override void SetTabela()
        {
            Tabela = "Produto";
        }

        protected override SqlParameter[] CriaParametros(ProdutoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("IdProduto", model.Id);
            parametros[1] = new SqlParameter("Nome", model.Nome);

            if (model == null)
                parametros[2] = new SqlParameter("Descricao", DBNull.Value);
            else
                parametros[2] = new SqlParameter("Descricao", model.Descricao);

            if (model == null)
                parametros[3] = new SqlParameter("Informacoes_Tecnicas", DBNull.Value);
            else
                parametros[3] = new SqlParameter("Informacoes_Tecnicas", model.InformacoesTecnicas);

            parametros[4] = new SqlParameter("IdCategoria", model.IdCategoria);
            parametros[5] = new SqlParameter("Preco", model.Preco);
            parametros[6] = new SqlParameter("IdMarca", model.IdMarca);
            parametros[7] = new SqlParameter("Estoque", model.Estoque);
            parametros[8] = new SqlParameter("Data_Criacao_Produto", model.DataCriacaoProduto);
            parametros[9] = new SqlParameter("IdArquivo", model.IdArquivo);
            return parametros;
        }

        protected override ProdutoViewModel MontaModel(DataRow registro)
        {
            ProdutoViewModel p = new ProdutoViewModel();
            p.Id = Convert.ToInt32(registro["IdProduto"]);
            p.Nome = registro["Nome"].ToString();

            if (registro["Descricao"] != DBNull.Value)
                p.Descricao = registro["Descricao"].ToString();

            if (registro["Informacoes_Tecnicas"] != DBNull.Value)
                p.InformacoesTecnicas = registro["Informacoes_Tecnicas"].ToString();

            p.IdCategoria = Convert.ToInt32(registro["IdCategoria"]);
            p.Preco = Convert.ToDecimal(registro["Preco"]);
            p.IdMarca = Convert.ToInt32(registro["IdMarca"]);
            p.Estoque = Convert.ToInt32(registro["Estoque"]);
            p.DataCriacaoProduto = Convert.ToDateTime(registro["Data_Criacao_Produto"]);
            p.IdArquivo = Convert.ToInt32(registro["IdArquivo"]);
            return p;
        }
    }
}
