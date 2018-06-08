using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace PATOnline.Controller.ClasesBD
{
    public class Usuario
    {
        public string query = "";
        public int idUsuario(string usuario)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * FROM seg_usuario WHERE username = '{0}';", usuario);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idusuario")))
                    {
                        return int.Parse(buscar["idusuario"].ToString());
                    }
                }
            }
            mysql.CerrarConexion();
            return 0;
        }


        public DataTable graficaUsuarioActivoInactivo()
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT e.nombre, COUNT(u.idusuario) FROM seg_usuario u " +
            "INNER JOIN seg_estado e ON e.idestado = u.fkestado " +
            "WHERE u.fkestado = 1 " +
            "UNION " +
            "SELECT e.nombre, COUNT(u.idusuario) FROM seg_usuario u " +
            "INNER JOIN seg_estado e ON e.idestado = u.fkestado " +
            "WHERE u.fkestado = 2");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable UsuarioRead()
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.idusuario as numero, CONCAT(u.primer_nombre, ' ',u.segundo_nombre,' ',u.primer_apellido,' ',u.segundo_apellido) as nombre_completo, " +
            "dbsecretaria.f.Direccion as direccion, u.telefono as telefono, u.correo_electronico as correo, " +
            "u.fkfadn as fadn, e.nombre as estado, r.nombre as rol, u.username as user " +
            "FROM seg_usuario u " +
            "INNER JOIN dbsecretaria.sg_fadn f ON dbsecretaria.f.nombre = u.fkfadn " +
            "INNER JOIN seg_estado e on e.idestado = u.fkestado " +
            "INNER JOIN seg_rol r on r.idrol = u.fkrol;");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}