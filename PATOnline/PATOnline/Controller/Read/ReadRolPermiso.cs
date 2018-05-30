using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadRolPermiso
    {
        public string query = "";
        public DataTable MenuPermisoRead(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT rmb.idmenu_boton as numero, m.nombre AS pantalla " +
            "FROM seg_menu_boton rmb " +
            "INNER JOIN seg_menu m ON m.idmenu = rmb.fkmenu " +
            "WHERE fkrol = '{0}'", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable BotonPermisoRead(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT rmb.idmenu_boton as numero, b.nombre AS boton " +
            "FROM seg_menu_boton rmb " +
            "INNER JOIN seg_boton b ON b.idboton = rmb.fkboton " +
            "INNER JOIN seg_menu m ON m.idmenu = rmb.fkmenu " +
            "INNER JOIN seg_rol r ON r.idrol = rmb.fkrol " +
            "WHERE rmb.idmenu_boton = '{0}'", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable RolReadUsuario(string usuario)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT r.nombre as rol " +
            "FROM seg_usuario u INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "WHERE u.username = '{0}'; ", usuario);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}