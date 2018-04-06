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
    public class SearchP2
    {
        public string query = "";
        public bool ExisteP2(int ingreso, string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT fkprograma_ac FROM pat_p2 " +
            "WHERE fadn = '{0}' AND anio = '{1}' AND fkprograma_ac = '{2}'; ", fadn, anio, ingreso);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("fkprograma_ac")))
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