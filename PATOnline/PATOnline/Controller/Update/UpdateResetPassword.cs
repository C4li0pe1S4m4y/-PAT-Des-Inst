using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PATOnline.Models;

namespace PATOnline.Controller.Update
{
    public class UpdateResetPassword
    {
        public string query = "";
        public DataTable PasswordReset(ModeloUsuario objEditar)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("UPDATE seg_usuario SET password=AES_ENCRYPT('{0}', 'SCOGA'), fkestado='1', " +
            "verificar=AES_ENCRYPT('{1}', 'SCOGA') WHERE username='{2}';",
            objEditar.password, objEditar.verifica, objEditar.user);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}