using MySql.Data.MySqlClient;
using System;
using PATOnline.Models;

namespace PATOnline.Controller.Update
{
    public class UpdateResetPassword
    {
        public string query = "";
        public Boolean PasswordReset(ModeloUsuario objEditar)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; UPDATE seg_usuario SET password=AES_ENCRYPT('{0}', 'SCOGA'), fkestado='1', " +
            "verificar=AES_ENCRYPT('{1}', 'SCOGA') WHERE username='{2}';",
            objEditar.password, objEditar.verifica, objEditar.user);
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