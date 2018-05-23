using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Delete
{
    public class DeleteUsuario
    {
        public string query = "";
        public Boolean UsuarioDelete(string id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; UPDATE seg_usuario SET password = AES_ENCRYPT('@Dm1NP4T0nliN3', 'SCOGA'), fkestado = 2 WHERE username = '{0}';", id);
            
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