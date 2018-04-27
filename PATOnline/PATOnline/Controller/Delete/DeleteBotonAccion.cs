using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Delete
{
    public class DeleteBotonAccion
    {
        public string query = "";
        public void MenuAccionDelete(int fkboton, int fkmenu, int fkrol)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("DELETE FROM seg_menu_boton WHERE fkboton='{0}' AND fkmenu='{1}' AND fkrol='{2}';", 
                fkboton, fkmenu, fkrol);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            mysql.CerrarConexion();
        }
    }
}