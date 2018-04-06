using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Search
{
    public class LoginUsuario
    {
        public string query = "";
        public bool LoginUser(string user)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT * " +
                "FROM seg_usuario " +
                "WHERE username='{0}' AND fkestado=1;", user);
                mysql.AbrirConexion();
                MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
                MySqlDataReader buscar = consulta.ExecuteReader();
                using (buscar)
                {
                    while (buscar.Read())
                    {
                        if (!string.IsNullOrEmpty(buscar.GetString("username")))
                        {
                            return true;
                        }
                    }
                }
                mysql.CerrarConexion();
                return false;
            }
            catch
            {
                throw;
            }
        }

        public bool LoginPassword(string user, string pass)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * " +
            "FROM seg_usuario " +
            "WHERE username='{0}' AND password =AES_ENCRYPT('{1}', 'SCOGA') AND fkestado=1;", user, pass);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("username")))
                    {
                        if (!string.IsNullOrEmpty(buscar.GetString("password")))
                        {
                            return true;
                        }
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }
    }
}