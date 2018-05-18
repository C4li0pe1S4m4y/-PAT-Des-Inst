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
    public class SearchRol
    {
        public string query = "";
        public string rol = null;
        public bool ExisteRol(string rol)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT r.nombre As Rol " +
            "FROM seg_rol r " +
            "WHERE r.nombre = '{0}'", rol);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("Rol")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public string NombreRol(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT u.fkrol as rol " +
            "FROM seg_usuario u " +
            "WHERE u.username = '{0}';", username);

            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    rol = reader["rol"].ToString();
                }
            }
            mysql.CerrarConexion();
            return rol;
        }
    }
}