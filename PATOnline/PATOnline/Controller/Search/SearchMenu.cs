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
    public class SearchMenu
    {
        public string query = "";
        public bool MenuRead(string username, string menu)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, m.nombre AS Menu " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_menu m ON m.idmenu = mb.fkmenu " +
            "WHERE u.username = '{0}' AND m.nombre = '{1}' GROUP BY(m.nombre);", username, menu);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Menu"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;           
        }

        public bool ExisteMenu(string menu)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT m.nombre As Menu " +
            "FROM seg_menu m " +
            "WHERE m.nombre = '{0}'", menu);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("Menu")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool MenuUsuario(string username, string menu)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, m.nombre AS Menu " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_menu m ON m.idmenu = mb.fkmenu " +
            "WHERE u.username = '{0}' AND m.nombre = '{1}' GROUP BY(m.nombre);", username, menu);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Menu"))))
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