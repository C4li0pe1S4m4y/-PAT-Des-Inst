using MySql.Data.MySqlClient;
using PATOnline.Models;
using System;

namespace PATOnline.Controller.Delete
{
    public class DeleteInfoBaseLegal
    {
        public string query = "";
        public Boolean InfoBaseLegalDelete(int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE pat_informacion SET fkestado = '11' WHERE idinformacion = '{0}';", id);

            try
            {
                mysql.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
                cmd.ExecuteNonQuery();
                mysql.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}