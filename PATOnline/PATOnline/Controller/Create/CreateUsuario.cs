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
            if(objCrear.correo != "")
            {
                query = String.Format("INSERT INTO seg_usuario (primer_nombre, segundo_nombre, " +
                "primer_apellido, segundo_apellido, telefono, correo_electronico, " +
                "password, fkfadn, fkestado, fkrol, username, verificar) " +
                "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', AES_ENCRYPT('@Dm1NP4T0nliN3', 'SCOGA'), '{6}', '2', '{7}', '{8}', AES_ENCRYPT('{9}', 'SCOGA'));",
                objCrear.nombre1, objCrear.nombre2, objCrear.apellido1, objCrear.apellido2, objCrear.telefono, objCrear.correo,
                objCrear.fkfadn, objCrear.fkrol, objCrear.user, objCrear.verifica);
            }
            else
            {
                query = String.Format("INSERT INTO seg_usuario (primer_nombre, segundo_nombre, " +
                "primer_apellido, segundo_apellido, telefono, " +
                "password, fkfadn, fkestado, fkrol, username, verificar) " +
                "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', AES_ENCRYPT('@Dm1NP4T0nliN3', 'SCOGA'), '{5}', '2', '{6}', '{7}', AES_ENCRYPT('{8}', 'SCOGA'));",
                objCrear.nombre1, objCrear.nombre2, objCrear.apellido1, objCrear.apellido2, objCrear.telefono, 
                objCrear.fkfadn, objCrear.fkrol, objCrear.user, objCrear.verifica);
            }
            mysql.AbrirConexion(); 
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}