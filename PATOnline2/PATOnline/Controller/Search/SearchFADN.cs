using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System;

namespace PATOnline.Controller.Search
{
    public class SearchFADN
    {
        public string query = "";
        public bool FADNSearch(string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT nombre FROM dbsecretaria.sg_fadn WHERE nombre = '{0}';", nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }
    }
}