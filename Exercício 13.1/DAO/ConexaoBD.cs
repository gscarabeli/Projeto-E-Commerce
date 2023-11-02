using System.Data.SqlClient;

namespace Exercício_13._1.DAO
{
    public static class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=LOCALHOST; Database=AULADB; user id=sa; password=123456"; //FESA
            //string strCon = "Data Source=DELL;Initial Catalog=AULADB;Integrated Security=SSPI;"; //Casa
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
