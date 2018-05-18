using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Search
{
    public class SerachUsuario
    {
        public string query = "";
        public bool BuscarCorreo(string correo)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * FROM seg_usuario WHERE correo_electronico='{0}';",correo);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("correo_electronico")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }
        public bool BuscarUsuario(string usuario)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * FROM seg_usuario WHERE username='{0}';", usuario);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("username")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }
        public DataTable UsuarioSearch(string id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.idusuario as numero, u.primer_nombre as nombre1, u.segundo_nombre as nombre2, " +
            "u.primer_apellido as apellido1, u.segundo_apellido as apellido2, " +
            "dbsecretaria.f.Direccion as direccion, u.telefono as telefono, u.correo_electronico as correo, " +
            "u.fkfadn as fadn, e.nombre as estado, r.nombre as rol, u.username as user " +
            "FROM seg_usuario u " +
            "INNER JOIN dbsecretaria.sg_fadn f ON dbsecretaria.f.nombre = u.fkfadn " +
            "INNER JOIN seg_estado e on e.idestado = u.fkestado " +
            "INNER JOIN seg_rol r on r.idrol = u.fkrol " +
            "WHERE u.username = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable UsuarioEditSearch(string id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.idusuario as numero, u.primer_nombre as nombre1, u.segundo_nombre as nombre2, " +
            "u.primer_apellido as apellido1, u.segundo_apellido as apellido2, " +
            "dbsecretaria.f.Direccion as direccion, u.telefono as telefono, u.correo_electronico as correo, " +
            "u.fkfadn as fadn, e.nombre as estado, u.fkrol as rol, u.username as user " +
            "FROM seg_usuario u " +
            "INNER JOIN dbsecretaria.sg_fadn f ON dbsecretaria.f.nombre = u.fkfadn " +
            "INNER JOIN seg_estado e on e.idestado = u.fkestado " +
            "INNER JOIN seg_rol r on r.idrol = u.fkrol " +
            "WHERE u.username = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public bool EstadoUsuario(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT username FROM seg_usuario WHERE idusuario='{0}' AND fkestado=1;", id);
                mysql.AbrirConexion();
                MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
                MySqlDataReader buscar = consulta.ExecuteReader();
                using (buscar)
                {
                    while (buscar.Read())
                    {
                        if (!string.IsNullOrEmpty(buscar.GetString("username")))
                        {
                            return true;
                        }
                    }
                }
                mysql.CerrarConexion();
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}