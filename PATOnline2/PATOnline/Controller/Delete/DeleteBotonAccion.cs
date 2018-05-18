using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Delete
{
    public class DeleteBotonAccion
    {
        public string query = "";
        public string sub_query = "";
        public int id;
        public void MenuAccionDelete(int fkboton, int fkmenu, int fkrol)
        {
            var mysql = new DBConnection.ConexionMysql();
            id = 0;
            sub_query = String.Format("SELECT idmenu_boton FROM seg_menu_boton WHERE fkboton='{0}' AND fkmenu='{1}' AND fkrol='{2}';",
            fkboton, fkmenu, fkrol);
            mysql.AbrirConexion();
            MySqlCommand cmd = new MySqlCommand(sub_query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    id = int.Parse(reader["idmenu_boton"].ToString());
                }
            }
            mysql.CerrarConexion();

            if(id != 0)
            {
                query = String.Format("DELETE FROM seg_menu_boton " +
                "WHERE idmenu_boton = {0}", id);
                mysql.AbrirConexion();
                MySqlCommand delete = new MySqlCommand(query, mysql.conectar);
                delete.ExecuteNonQuery();
                mysql.CerrarConexion();
            }
        }
    }
}