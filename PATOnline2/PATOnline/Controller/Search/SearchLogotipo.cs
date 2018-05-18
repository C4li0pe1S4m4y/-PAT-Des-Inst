using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System;

namespace PATOnline.Controller.Search
{
    public class SearchLogotipo
    {
        public string query = "";
        public string logotipo = null;
        public string LogotipoFederacion(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT logo " +
            "FROM dbsecretaria.sg_logotipo " +
            "INNER JOIN dbsecretaria.sg_fadn ON id_fand = fkfadn " +
            "WHERE nombre = '{0}';", username);
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    logotipo = reader["logo"].ToString();
                }
            }
            mysql.CerrarConexion();
            return logotipo;
        }
    }
}