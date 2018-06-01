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
    public class ReadC3_2
    {
        public string query = "";
        public DataTable C3_2Read(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c3.idc3_2 AS numero, c3.codigo AS codigo, act.nombre AS actividad, cat.nombre AS categoria, " +
            "c3.edades AS edades, c3.masculino AS mas, c3.femenino AS fem, c3.total_f_m AS total, " +
            "c3.registro AS registro, c3.inicio_dia AS inicio_dia, c3.inicio_mes AS inicio_mes, " +
            "c3.fin_dia AS fin_dia, c3.fin_mes AS fin_mes, c3.departamento AS departamento, " +
            "c3.lugar AS lugar, c3.presupuesto AS presupuesto " +
            "FROM pat_c3_2 c3 " +
            "INNER JOIN admin_actividad_pat act ON act.idactividad_pat = c3.fkactividad " +
            "INNER JOIN admin_categoria cat ON cat.idcategoria = c3.fkcategoria " +
            "WHERE c3.fadn = '{0}' AND c3.ano = '{1}';", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C3_2TotalRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT c3.idc3_2 AS numero, SUM(c3.presupuesto) AS total " +
            "FROM pat_c3_2 c3 WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}