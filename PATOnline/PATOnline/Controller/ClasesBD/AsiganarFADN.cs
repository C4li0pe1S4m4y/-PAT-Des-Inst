using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class AsiganarFADN
    {
        public string query = "";

        //Funcion para crear un nuevo registro
        public DataTable crearAsignacionUsuario(ModeloAsignarFADN o)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO admin_asignar_fadn (nombre_fadn, fkusuario) " +
            "VALUES('{0}', '{1}'); ", o.federacion, o.fkusuario);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        //Funcion para llenar el grid
        public DataTable AsignacionFADNRead()
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT af.idasignar_fadn AS numero, CONCAT(u.primer_nombre,' ',u.segundo_nombre,' ',u.primer_apellido,' ',u.segundo_apellido) AS usuario, " +
            "af.nombre_fadn AS federacion " +
            "FROM admin_asignar_fadn af " +
            "INNER JOIN seg_usuario u  ON u.idusuario = af.fkusuario");

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        //Funcion para seleccionar informacion
        public DataTable AsignacionFADNSeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idasignar_fadn, fkusuario, nombre_fadn FROM admin_asignar_fadn " +
            "WHERE idasignar_fadn = '{0}'", id);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        //Funcion para verificar si existe la informacion
        public bool AsignacionFADNExiste(int fkusuaro, string fadn)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idasignar_fadn FROM admin_asignar_fadn " +
            "WHERE fkusuario = '{0}' AND nombre_fadn = '{1}'", fkusuaro, fadn);

            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idasignar_fadn")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        //Funcion para eliminar la informacion 
        public Boolean AsignacionFADNDelete(int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("DELETE FROM admin_asignar_fadn WHERE idasignar_fadn = '{0}'", id);

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

        //Funcion para actualizar la informacion
        public Boolean AsignacionFADNUpdate(ModeloAsignarFADN o, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE admin_asignar_fadn SET fkusuario = '{0}', nombre_fadn = '{1}' WHERE idasignar_fadn = '{2}'", 
            o.fkusuario, o.federacion, id);

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