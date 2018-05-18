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
    public class ReadC3_1
    {
        public string query = "";
        public DataTable C3_1Read(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c3.idc3_1 AS numero, c3.codigo AS codigo, c3.nombre_competencia AS competencia, cla.nombre AS clasificacion, " +
            "n.nombre AS nivel, cat.nombre AS categoria, c3.edades AS edades, c3.fase_evento AS fase, " +
            "c3.resultado AS resultado, c3.registro AS registro, c3.inicio_dia AS inicio_dia, " +
            "c3.inicio_mes AS inicio_mes, c3.fin_dia AS fin_dia, c3.fin_mes AS fin_mes, " +
            "d.nombre AS departamento, c3.lugar AS lugar, c3.presupuesto AS presupuesto " +
            "FROM pat_c3_1 c3 " +
            "INNER JOIN admin_clasificacion cla ON cla.idclasificacion = c3.fkclasificacion " +
            "INNER JOIN admin_nivel n ON n.idnivel = c3.fknivel " +
            "INNER JOIN admin_categoria cat ON cat.idcategoria = c3.fkcategoria " +
            "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = c3.fkpais_departamento " +
            "WHERE c3.fadn = '{0}' AND c3.ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C3_1TotalRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c3.idc3_1 AS numero, SUM(c3.presupuesto) AS total " +
            "FROM pat_c3_1 c3 WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}