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
    public class SearchPermisoRol
    {
        public string query = "";

        public DataTable RolPermisoSearch(int rol, int menu)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

                query = String.Format("SELECT rmb.idmenu_boton as numero, r.nombre AS rol, b.nombre AS boton, m.nombre AS pantalla " +
                "FROM seg_menu_boton rmb " +
                "INNER JOIN seg_rol r ON r.idrol = rmb.fkrol " +
                "INNER JOIN seg_boton b ON b.idboton = rmb.fkboton " +
                "INNER JOIN seg_menu m ON m.idmenu = rmb.fkmenu " +
                "WHERE r.idrol = '{0}' AND m.idmenu = '{1}';", rol, menu);

                mysql.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
                consulta.Fill(dt);
                mysql.CerrarConexion();
                return dt;
        }

        public bool RolPermisoExiste(int rol, int menu, int boton)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idmenu_boton AS nombre " +
            "FROM seg_menu_boton " +
            "WHERE fkrol = {0} AND fkmenu = {1} AND fkboton = {2};", rol, menu, boton);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public DataTable ExisteBotonenPermisoSearch(int rol, int menu)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT b.nombre AS boton " +
            "FROM seg_menu_boton rmb " +
            "INNER JOIN seg_rol r ON r.idrol = rmb.fkrol " +
            "INNER JOIN seg_boton b ON b.idboton = rmb.fkboton " +
            "INNER JOIN seg_menu m ON m.idmenu = rmb.fkmenu " +
            "WHERE r.idrol = '{0}' AND m.idmenu = '{1}';", rol, menu);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}