using MySql.Data.MySqlClient;
using System;
using PATOnline.Models;

namespace PATOnline.Controller.Update
{
    public class UpdateUsuario
    {
        public string query = "";
        public Boolean UsuarioUpdate(ModeloUsuario objEditar, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (objEditar.correo != "" || objEditar.correo != null)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; UPDATE seg_usuario SET primer_nombre = '{0}', segundo_nombre = '{1}', " +
                "primer_apellido = '{2}', segundo_apellido = '{3}', telefono = '{4}', " +
                "correo_electronico = '{5}', fkfadn = '{6}', fkrol = '{7}', " +
                "username = '{8}', verificar = AES_ENCRYPT('{9}', 'SCOGA') WHERE idusuario = '{10}';",
                objEditar.nombre1, objEditar.nombre2, objEditar.apellido1, objEditar.apellido2, objEditar.telefono,
                objEditar.correo, objEditar.fkfadn, objEditar.fkrol, objEditar.user, objEditar.verifica, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; UPDATE seg_usuario SET primer_nombre = '{0}', segundo_nombre = '{1}', " +
                "primer_apellido = '{2}', segundo_apellido = '{3}', telefono = '{4}', " +
                "fkfadn = '{5}', fkrol = '{6}', " +
                "username = '{7}', verificar = AES_ENCRYPT('{8}', 'SCOGA') WHERE idusuario = '{9}';",
                objEditar.nombre1, objEditar.nombre2, objEditar.apellido1, objEditar.apellido2, objEditar.telefono,
                objEditar.fkfadn, objEditar.fkrol, objEditar.user, objEditar.verifica, id);
            }
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

        public Boolean UsuarioUpdateActivar(ModeloUsuario objEditar, string id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; UPDATE seg_usuario SET password = AES_ENCRYPT('@Dm1NP4T0nliN3', 'SCOGA'), verificar = AES_ENCRYPT('{0}', 'SCOGA'), fkestado = 1 WHERE username = '{1}';",
            objEditar.verifica, id);

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