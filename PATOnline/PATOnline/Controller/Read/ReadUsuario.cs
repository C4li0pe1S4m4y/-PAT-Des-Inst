using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Read
{
    public class ReadUsuario
    {
        public string query = "";
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