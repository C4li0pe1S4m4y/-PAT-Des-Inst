using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Delete
{
    public class DeleteUsuario
    {
        public string query = "";
        public void UsuarioDelete(int fke, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("UPDATE seg_usuario SET fkestado = {0} WHERE idusuario = {1};", fke, id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            mysql.CerrarConexion();
        }
    }
}