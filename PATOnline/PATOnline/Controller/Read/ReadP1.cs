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
    public class ReadP1
    {
        public string query = "";
        public string add = null;
        public DataTable Part9Read()
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idingreso_corriente AS idnumero1 FROM admin_ingreso_corriente " +
            "WHERE subpadre = '0' OR idingreso_corriente = '1' OR idingreso_corriente = '2';");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
        public DataTable Part11Read(int id1, string fadn, string anio)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(id1 == 3)
            {
                add = "WHERE idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' OR idingreso_corriente = '{0}' OR idingreso_corriente = '1' GROUP BY (ic.codigo);";
            }
            if(id1 >= 4 || id1 <= 7)
            {
                add = "WHERE idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' OR idingreso_corriente = '{0}' GROUP BY (ic.codigo);";
            }
            if(id1 == 8)
            {
                add = "WHERE idpadre = '2' AND subpadre = '{0}' AND ic.fadn = '{1}' OR idingreso_corriente = '{0}' OR idingreso_corriente = '2' GROUP BY (ic.codigo);";
            }
            query = String.Format("SELECT ic.idingreso_corriente AS idnumero2, ic.codigo AS codigo, " +
            "ic.nombre AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, p.col_tres AS monto3 " +
            "FROM pat_p1 p RIGHT JOIN admin_ingreso_corriente ic " +
            "ON ic.idingreso_corriente = p.fkingreso_corriente " + add, id1, fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
        public DataTable TotalP1Read(string fadn, string anio)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idp1 AS idnumero2, SUM(col_uno) AS total1, SUM(col_dos) AS total2, SUM(col_tres) AS total3 " +
            "FROM pat_p1 WHERE fadn = '{0}' AND ano = '{1}';", fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}