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
    public class SearchIngreso
    {
        public string query = "";
        public bool ExisteCodigoIngreso(string codigo, string fadn)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idingreso_corriente FROM admin_ingreso_corriente " +
            "WHERE codigo = '{0}' AND fadn = '{1}'; ", codigo, fadn);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idingreso_corriente")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool ExisteNombreIngreso(string nombre, string fadn)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idingreso_corriente FROM admin_ingreso_corriente " +
            "WHERE nombre = '{0}' AND fadn = '{1}'; ", nombre, fadn);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idingreso_corriente")))
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