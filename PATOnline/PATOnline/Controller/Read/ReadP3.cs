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
    public class ReadP3
    {
        public string query = "";
        public DataTable Part3Read(string fadn, string anio)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idp3 AS numero, pat_p3.* FROM pat_p3 " +
            "WHERE fadn = '{0}' AND ano = '{1}';", fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PartTotalRead(string fadn, string anio)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idp3 AS numero, SUM(promocion) AS total1, SUM(programa) AS total2, SUM(actividad) AS total3, " +
            "SUM(subtotal) AS total4, SUM(otra_fuente) AS total5, SUM(total) AS total6 " +
            "FROM pat_p3 WHERE fadn = '{0}' AND ano = '{1}'; ", fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}