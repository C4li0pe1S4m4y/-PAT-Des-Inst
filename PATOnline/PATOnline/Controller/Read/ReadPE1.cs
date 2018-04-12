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
    public class ReadPE1
    {
        public string query = "";
        public DataTable PE1Read(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT p.idpe1 AS numero, p.codigo AS codigo, a.nombre AS actividad, " +
            "p.resultado AS resultado, p.registro AS registro, p.inicio_dia AS inicio_dia, " +
            "p.inicio_mes AS inicio_mes, p.fin_dia AS fin_dia, p.fin_mes AS fin_mes, " +
            "d.nombre AS departamento, pa.nombre AS pais, p.lugar AS lugar, p.presupuesto AS presupuesto " +
            "FROM pat_pe1 p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
            "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = p.fkpais_departamento " +
            "INNER JOIN admin_pais_departamento pa ON pa.idpais_departamento = d.idpadre " +
            "WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PE1TotalRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT p.idpe1 AS numero, SUM(p.presupuesto) AS total " +
            "FROM pat_pe1 p WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}