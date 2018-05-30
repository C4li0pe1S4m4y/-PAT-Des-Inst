using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Read
{
    public class ReadBoton
    {
        public string query = "";
        public DataTable BotonRead()
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idboton as numero, nombre as boton FROM seg_boton");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable BotonReadUsuario(string usuario, string menu)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT b.nombre as boton " +
            "FROM seg_usuario u INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "INNER JOIN seg_menu m ON m.idmenu = mb.fkmenu " +
            "WHERE u.username = '{0}' AND m.nombre = '{1}' AND r.idrol = mb.fkrol;",usuario, menu);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}