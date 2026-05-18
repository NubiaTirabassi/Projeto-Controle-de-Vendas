using MySql.Data.MySqlClient;
using System.Configuration;

namespace Projeto_Controle_de_Vendas.br.com.projeto.conexaoDB
{
    public class ConnectionFactory
    {
        public MySqlConnection getConnection()
        {
            string conexaoDataBase = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;
            return new MySqlConnection(conexaoDataBase);
        }
    }
}
