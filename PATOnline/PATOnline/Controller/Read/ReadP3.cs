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
            query = String.Format("SELECT p3.idp3 AS numero, pe1.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_pe1 pe1 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = pe1.codigo " +
            "WHERE pe1.fadn = '{0}' AND pe1.ano = '{1}' " +
            "GROUP BY(pe1.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, pe2.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_pe2 pe2 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = pe2.codigo " +
            "WHERE pe2.fadn = '{0}' AND pe2.ano = '{1}' " +
            "GROUP BY(pe2.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c1_1.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c1_1 c1_1 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c1_1.codigo " +
            "WHERE c1_1.fadn = '{0}' AND c1_1.ano = '{1}' " +
            "GROUP BY(c1_1.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c2_1.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c2_1 c2_1 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_1.codigo " +
            "WHERE c2_1.fadn = '{0}' AND c2_1.ano = '{1}' " +
            "GROUP BY(c2_1.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c2_2.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c2_2 c2_2 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_2.codigo " +
            "WHERE c2_2.fadn = '{0}' AND c2_2.ano = '{1}' " +
            "GROUP BY(c2_2.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c2_3.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c2_3 c2_3 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_3.codigo " +
            "WHERE c2_3.fadn = '{0}' AND c2_3.ano = '{1}' " +
            "GROUP BY(c2_3.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c3_1.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c3_1 c3_1 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c3_1.codigo " +
            "WHERE c3_1.fadn = '{0}' AND c3_1.ano = '{1}' " +
            "GROUP BY(c3_1.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c3_2.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c3_2 c3_2 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c3_2.codigo " +
            "WHERE c3_2.fadn = '{0}' AND c3_2.ano = '{1}' " +
            "GROUP BY(c3_2.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c4_1.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c4_1 c4_1 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_1.codigo " +
            "WHERE c4_1.fadn = '{0}' AND c4_1.ano = '{1}' " +
            "GROUP BY(c4_1.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c4_2.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c4_2 c4_2 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_2.codigo " +
            "WHERE c4_2.fadn = '{0}' AND c4_2.ano = '{1}' " +
            "GROUP BY(c4_2.codigo) " +
            "UNION " +
            "SELECT p3.idp3 AS numero, c4_3.codigo AS codigo, p3.promocion AS promocion, " +
            "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
            "p3.otra_fuente AS otra_fuente, p3.total AS total " +
            "FROM pat_c4_3 c4_3 " +
            "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_3.codigo " +
            "WHERE c4_3.fadn = '{0}' AND c4_3.ano = '{1}' " +
            "GROUP BY(c4_3.codigo)", fadn, anio);
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