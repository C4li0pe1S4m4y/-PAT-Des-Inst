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
    public class ReadP2
    {
        public string query = "";
        public string add = null;
        public DataTable Part9Read()
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idprograma_ac AS idnumero1, proyeccion_egresos FROM admin_programa_ac " +
            "WHERE subpadre = '0' AND idpadre = '1' AND idprograma_ac != '3';");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
        public DataTable Part10Read()
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idprograma_ac AS idnumero1, proyeccion_egresos FROM admin_programa_ac " +
            "WHERE subpadre = '0' AND idpadre = '2';");
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
            if (id1 == 3)
            {
                add = "WHERE idpadre = '1' AND subpadre = '{0}' OR idprograma_ac = '{0}' OR idprograma_ac = '1' GROUP BY (pac.idprograma_ac);";
            }
            else
            {
                add = "WHERE idpadre = '1' AND subpadre = '{0}' OR idprograma_ac = '{0}' GROUP BY (pac.idprograma_ac);";
            }
            query = String.Format("SELECT pac.idprograma_ac AS idnumero2, pac.renglon AS renglon, " +
            "pac.proyeccion_egresos AS nombre, CONCAT('Q ', p.col_uno) AS monto1, CONCAT('Q ', p.col_dos) AS monto2, CONCAT('Q ', p.col_tres) AS monto3, " +
            "CONCAT('Q ', p.col_cuatro) AS monto4, p.col_cinco AS finanza " +
            "FROM pat_p2 p RIGHT JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac IN(SELECT fkprograma_ac FROM pat_p2 " +
            "INNER JOIN admin_programa_ac ON idprograma_ac = fkprograma_ac WHERE fadn = '{1}' AND anio = '{2}' AND subpadre = '{0}') " + add, id1, fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
        public DataTable TotalP2Read(string fadn, string anio)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idp2 AS idnumero2, CONCAT('TOTAL EGRESOS POR RENGLON Q') AS nombre, " +
            "SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
            "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
            "FROM pat_p2 INNER JOIN admin_programa_ac ON idprograma_ac = fkprograma_ac " +
            "WHERE fadn = '{0}' AND anio = '{1}' AND idpadre = '1' " +
            "UNION " +
            "SELECT idp2 AS idnumero2, CONCAT('TOTAL EGRESOS OTRAS FUENTES Q') AS nombre, SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
            "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
            "FROM pat_p2 INNER JOIN admin_programa_ac ON idprograma_ac = fkprograma_ac " +
            "WHERE fadn = '{0}' AND anio = '{1}' AND idpadre = '2' " +
            "UNION " +
            "SELECT idp2 AS idnumero2, CONCAT('TOTAL GENERAL Q') AS nombre, SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
            "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
            "FROM pat_p2 WHERE fadn = '{0}' AND anio = '{1}'; ", fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
        public DataTable SubTotalP2Read(int id, string fadn, string anio)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT pac.idprograma_ac AS idnumero2, pac.renglon AS renglon, " +
            "CONCAT('Sub Total Q') AS nombre, SUM(p.col_uno) AS sub1, SUM(p.col_dos) AS sub2, " +
            "SUM(p.col_tres) AS sub3, SUM(p.col_cuatro) AS sub4 " +
            "FROM pat_p2 p RIGHT JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac IN(SELECT fkprograma_ac FROM pat_p2 WHERE fadn = '{1}' AND anio = '{2}') " +
            "WHERE idpadre = '1' AND subpadre = '{0}'; ", id, fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable SubyTotalP2Read(int id, string fadn, string anio)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            add = "WHERE idpadre = '1' AND subpadre = '{0}' OR idprograma_ac = '{0}' AND idprograma_ac != '1' AND idprograma_ac != '3' GROUP BY (pac.idprograma_ac)";

            query = String.Format("SELECT pac.idprograma_ac AS idnumero2, pac.renglon AS renglon, " +
            "pac.proyeccion_egresos AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, " +
            "p.col_tres AS monto3, p.col_cuatro AS monto4, p.col_cinco AS finanza " +
            "FROM pat_p2 p RIGHT JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac = p.fkprograma_ac " + add +
            "UNION " +
            "SELECT pac.idprograma_ac AS idnumero2, null, CONCAT('SUB TOTAL Q') AS nombre, " +
            "SUM(p.col_uno) AS monto1, SUM(p.col_dos) AS monto2," +
            "SUM(p.col_tres) AS monto3, SUM(p.col_cuatro) AS monto4, 0 " +
            "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac = p.fkprograma_ac " +
            "WHERE idpadre = '1' AND subpadre = '{0}' AND fadn = '{1}' AND anio = '{2}' AND idprograma_ac != '1' AND idprograma_ac != '3';", id, fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
        public DataTable SubyTotal2P2Read(int id, string fadn, string anio)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            add = "WHERE idpadre = '2' AND subpadre = '{0}' OR idprograma_ac = '{0}' GROUP BY (pac.idprograma_ac)";

            query = String.Format("SELECT pac.idprograma_ac AS idnumero2, pac.renglon AS renglon, " +
            "pac.proyeccion_egresos AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, " +
            "p.col_tres AS monto3, p.col_cuatro AS monto4, p.col_cinco AS finanza " +
            "FROM pat_p2 p RIGHT JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac = p.fkprograma_ac " + add +
            "UNION " +
            "SELECT pac.idprograma_ac AS idnumero2, null, CONCAT('SUB TOTAL Q') AS nombre, " +
            "SUM(p.col_uno) AS monto1, SUM(p.col_dos) AS monto2," +
            "SUM(p.col_tres) AS monto3, SUM(p.col_cuatro) AS monto4, 0 " +
            "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac = p.fkprograma_ac " +
            "WHERE idpadre = '2' AND subpadre = '{0}' AND fadn = '{1}' AND anio = '{2}' AND idprograma_ac != '2';", id, fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}