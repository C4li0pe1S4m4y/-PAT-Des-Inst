using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.Create
{
    public class CreateRol
    {
        public string query = "";
        public DataTable RolCreate(ModeloRol objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO seg_rol (nombre)" +
            "VALUES('{0}');",
            objCrear.nombre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public void PermisoRolDelete(int rol, int menu)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("DELETE FROM seg_menu_boton WHERE fkrol = '{0}' AND fkmenu = '{1}'", rol, menu);
            mysql.AbrirConexion();
            MySqlCommand delete = new MySqlCommand(query, mysql.conectar);
            delete.ExecuteNonQuery();
            mysql.CerrarConexion();
        }
    }
}