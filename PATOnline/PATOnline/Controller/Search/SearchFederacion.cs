using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System;

namespace PATOnline.Controller.Search
{
    public class SearchFederacion
    {
        public string query = "";
        public string federacion = null;
        public string NombreFederacion(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT u.fkfadn as federacion " +
            "FROM seg_usuario u " +
            "WHERE u.username = '{0}';", username);

            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    federacion = reader["federacion"].ToString();
                }
            }
            mysql.CerrarConexion();
            return federacion;
        }
    }
}