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
    public class ReadRolPermiso
    {
        public string query = "";
        public DataTable RolPermisoRead()
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT rmb.idmenu_boton as numero, r.nombre AS rol, b.nombre AS boton, m.nombre AS pantalla " +
            "FROM seg_menu_boton rmb " +
            "INNER JOIN seg_rol r ON r.idrol = rmb.fkrol " +
            "INNER JOIN seg_boton b ON b.idboton = rmb.fkboton " +
            "INNER JOIN seg_menu m ON m.idmenu = rmb.fkmenu;");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}