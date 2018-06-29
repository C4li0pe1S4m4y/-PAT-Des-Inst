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
    public class ReadCPE
    {
        public string query = "";
        public DataTable CPERead(string fadn, string ano, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT cpe.idcpe AS numero, fc.nombre AS formato, cpe.ene_abr AS bimestre1, cpe.may_ago AS bimestre2, " +
            "cpe.sep_dic AS bimestre3, anual AS anual, cpe.presupuesto AS presupuesto " +
            "FROM pat_cpe cpe " +
            "INNER JOIN admin_formato_c fc ON fc.idformato_c = cpe.fkformato_c " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND idpadre = '{2}' ORDER BY (fkformato_c); ", fadn, ano, id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CPETotalRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT cpe.idcpe AS numero, SUM(cpe.presupuesto) AS total " +
            "FROM pat_cpe cpe WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

    }
}