using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadRol
    {
        public string query = "";
        public DataTable RolRead()
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idrol as numero, nombre as rol FROM seg_rol");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public string ConsultarRolRead(string menu)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT r.nombre AS rol " +
            "FROM seg_menu_boton rmb " +
            "INNER JOIN seg_menu m ON m.idmenu = rmb.fkmenu " +
            "INNER JOIN seg_rol r ON r.idrol = rmb.fkrol " +
            "WHERE m.nombre = '{0}'", menu);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("rol")))
                    {
                        return buscar["rol"].ToString();
                    }
                }
            }
            mysql.CerrarConexion();
            return "";
        }
    }
}