using MySql.Data.MySqlClient;
using System;
using PATOnline.Models;

namespace PATOnline.Controller.Update
{
    public class UpdateAdministracion
    {
        public string query = "";

        public Boolean UpdateBrecha(ModeloBrecha objEditar, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE admin_brecha SET nombre = '{0}' WHERE idbrecha = '{1}';",
            objEditar.nombre_brecha, id);
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

        public Boolean UpdateCargo(ModeloCargo objEditar, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE admin_cargo SET nombre = '{0}' WHERE idcargo = '{1}';",
            objEditar.nombre_cargo, id);
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

        public Boolean UpdateCategoria(ModeloCategoria objEditar, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE admin_categoria SET nombre = '{0}' WHERE idcategoria = '{1}';",
            objEditar.nombre_categoria, id);
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

        public Boolean UpdateNivel(ModeloNivel objEditar, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE admin_nivel SET nombre = '{0}', idpadre = '{1}' WHERE idnivel = '{2}';",
            objEditar.nombre_nivel, objEditar.idpadre, id);
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

        public Boolean UpdateTipoPersona(ModeloTipoPersonal objEditar, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE admin_tipo_personal_fadn SET nombre = '{0}' WHERE idtipo_personal_fadn = '{1}';",
            objEditar.nombre_tipopersonal, id);
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