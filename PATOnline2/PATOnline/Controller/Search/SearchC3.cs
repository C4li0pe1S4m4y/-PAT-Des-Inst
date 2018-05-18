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
    public class SearchC3
    {
        public string query = "";
        public bool ExisteC3(int id, string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT fkformato_c FROM pat_c3 WHERE fkformato_c = '{0}' AND ano = '{1}' AND fadn = '{2}';", id, anio, fadn);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("fkformato_c")))
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