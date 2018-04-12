using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PATOnline.Models;

namespace PATOnline.Controller.Update
{
    public class UpdateUsuario
    {
        public string query = "";
        public DataTable UsuarioUpdate(ModeloUsuario objEditar, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("UPDATE seg_usuario SET primer_nombre = '{0}', segundo_nombre = '{1}', " +
            "primer_apellido = '{2}', segundo_apellido= '{3}', direccion = '{4}', telefono = '{5}', correo_electronico = '{6}', " +
            "password = AES_ENCRYPT('{7}', 'SCOGA'), fkpais_departamento = '{8}', fkfadn = '{9}', fkestado = '{10}', fkrol = '{11}', username = '{12}' " +
            "WHERE idusuario = '{13}';", objEditar.nombre1, objEditar.nombre2, objEditar.apellido1,
            objEditar.apellido2, objEditar.direccion, objEditar.telefono, objEditar.correo, objEditar.password,
            objEditar.fkpais, objEditar.fkfadn, objEditar.fkestado, objEditar.fkrol, objEditar.user, id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}