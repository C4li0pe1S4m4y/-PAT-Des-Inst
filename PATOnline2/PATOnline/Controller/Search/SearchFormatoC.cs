using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
namespace PATOnline.Controller.Search
{
    public class SearchFormatoC
    {
        public string query = "";
        public bool ExisteFormatoCPAT(string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idformato_c FROM dbcdagpat.admin_formato_c WHERE nombre = '{0}';", nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idformato_c")))
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