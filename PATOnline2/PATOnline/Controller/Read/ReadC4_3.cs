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
    public class ReadC4_3
    {
        public string query = "";
        public DataTable C4_3Read(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c4.idc4_3 AS numero, c4.codigo AS codigo,  c4.competencia AS competencia, " +
            "c.nombre AS clasificacion, n.nombre AS nivel, cat.nombre AS categoria, c4.edades AS edades, " +
            "c4.linea AS linea, c4.resultado AS resultado, c4.registro AS registro, " +
            "c4.inicio_dia AS inicio_dia, c4.inicio_mes AS inicio_mes, c4.fin_dia AS fin_dia, " +
            "c4.fin_mes AS fin_mes, p.nombre AS pais, c4.lugar AS lugar, c4.presupuesto AS presupuesto " +
            "FROM pat_c4_3 c4 INNER JOIN admin_clasificacion c ON c.idclasificacion = c4.fkclasificacion " +
            "INNER JOIN admin_nivel n ON n.idnivel = c4.fknivel " +
            "INNER JOIN admin_categoria cat ON cat.idcategoria = c4.fkcategoria " +
            "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = c4.fkpais_departamento " +
            "WHERE c4.fadn = '{0}' AND c4.ano = '{1}';", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_3TotalRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c4.idc4_3 AS numero, SUM(c4.presupuesto) AS total " +
            "FROM pat_c4_3 c4 WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}