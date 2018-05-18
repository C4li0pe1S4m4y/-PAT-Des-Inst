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
    public class ReadC4_2
    {
        public string query = "";
        public DataTable C4_2Read(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c4.idc4_2 AS numero, c4.codigo AS codigo,  c4.actividad AS actividad, " +
            "n.nombre AS nivel, o.nombre AS objetivo, ep.nombre AS etapa, c.nombre AS categoria, " +
            "c4.linea AS linea, c4.registro AS registro, c4.inicio_dia AS inicio_dia, " +
            "c4.inicio_mes AS inicio_mes, c4.fin_dia AS fin_dia, c4.fin_mes AS fin_mes, " +
            "c4.departamento AS departamento, p.nombre AS pais, c4.lugar AS lugar, " +
            "c4.presupuesto AS presupuesto " +
            "FROM pat_c4_2 c4 INNER JOIN admin_nivel n ON n.idnivel = c4.fknivel " +
            "INNER JOIN admin_objetivo o ON o.idobjetivo = c4.fkobjetivo " +
            "INNER JOIN admin_etapa_preparacion ep ON ep.idetapa_preparacion = c4.fketapa_prepacion " +
            "INNER JOIN admin_categoria c ON c.idcategoria = c4.fkcategoria " +
            "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = c4.fkpais_departamento " +
            "WHERE c4.fadn = '{0}' AND c4.ano = '{1}';", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_2TotalRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c4.idc4_2 AS numero, SUM(c4.presupuesto) AS total " +
            "FROM pat_c4_2 c4 WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}