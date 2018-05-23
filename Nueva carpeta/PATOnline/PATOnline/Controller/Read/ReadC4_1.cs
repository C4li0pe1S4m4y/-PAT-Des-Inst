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
    public class ReadC4_1
    {
        public string query = "";
        public DataTable C4_1Read(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c4.idc4_1 AS numero, c4.codigo AS codigo, act.nombre AS actividad, " +
            "c4.descripcion AS descripcion, o.nombre AS objetivo, ep.nombre AS etapa, " +
            "c4.dirigido AS dirigido, c4.linea AS linea, c.nombre AS categoria, " +
            "c4.registro AS registro, c4.inicio_dia AS inicio_dia, c4.inicio_mes AS inicio_mes, " +
            "c4.fin_dia AS fin_dia, c4.fin_mes AS fin_mes, d.nombre AS departamento, " +
            "p.nombre AS pais, c4.lugar AS lugar, c4.presupuesto AS presupuesto " +
            "FROM pat_c4_1 c4 INNER JOIN admin_actividad_pat act ON act.idactividad_pat = c4.fkactividad " +
            "INNER JOIN admin_objetivo o ON o.idobjetivo = c4.fkobjetivo " +
            "INNER JOIN admin_etapa_preparacion ep ON ep.idetapa_preparacion = c4.fketapa_preparacion " +
            "INNER JOIN admin_categoria c ON c.idcategoria = c4.fkcategoria " +
            "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = c4.fkpais_departamento " +
            "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = d.idpadre " +
            "WHERE c4.fadn = '{0}' AND c4.ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_1TotalRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c4.idc4_1 AS numero, SUM(c4.presupuesto) AS total " +
            "FROM pat_c4_1 c4 WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}