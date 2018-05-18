using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PATOnline.Models;

namespace PATOnline.Controller.Create
{
    public class CreateUsuario
    {
        public string query = "";
        public DataTable UsuarioCreate(ModeloUsuario objCrear)
        {       
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO seg_usuario (primer_nombre, segundo_nombre, " +
            "primer_apellido, segundo_apellido, direccion, telefono, correo_electronico, " +
            "password, fkpais_departamento, fkfadn, fkestado, fkrol, username, verificar) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',AES_ENCRYPT('@Dm1NP4T0nliN3', 'SCOGA'), '{7}', '{8}', '2', '{9}', '{10}', AES_ENCRYPT('{11}', 'SCOGA'));",
            objCrear.nombre1, objCrear.nombre2, objCrear.apellido1, objCrear.apellido2, objCrear.direccion,
            objCrear.telefono, objCrear.correo, objCrear.fkpais, objCrear.fkfadn, objCrear.fkrol, objCrear.user, objCrear.verifica);
            mysql.AbrirConexion(); 
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}