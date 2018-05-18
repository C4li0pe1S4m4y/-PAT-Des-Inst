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
        public DataTable UsuarioSearch(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.idusuario as numero, CONCAT(u.primer_nombre, ' ',u.segundo_nombre,' ',u.primer_apellido,' ',u.segundo_apellido) as nombre_completo, " +
            "CONCAT(p.nombre,', ',d.nombre,', ',u.direccion) as direccion, u.telefono as telefono, u.correo_electronico as correo, " +
            "fa.nombre as fadn, t.nombre as tipo_fadn, e.nombre as estado, r.nombre as rol, u.username as user " +
            "FROM seg_usuario u INNER JOIN admin_pais_departamento p on p.idpadre = u.fkpais_departamento " +
            "INNER JOIN admin_pais_departamento d on d.idpais_departamento = u.fkpais_departamento " +
            "INNER JOIN admin_fadn fa on fa.idfadn = u.fkfadn INNER JOIN admin_tipo_fadn t on t.idtipo_fadn = fa.fktipo_fadn " +
            "INNER JOIN seg_estado e on e.idestado = u.fkestado INNER JOIN seg_rol r on r.idrol = u.fkrol WHERE u.idusuario='{0}';",id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

    }
}