using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class P3EgresosActividad
    {
        public string query = "";
        private double total_p1;
        private double total_p3;

        public DataTable P3Read(string fadn, string anio, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("SELECT p3.idp3 AS numero, pe1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_pe1 pe1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = pe1.codigo " +
                "WHERE pe1.fadn = '{0}' AND pe1.ano = '{1}' AND pe1.fkestado = '{2}' " +
                "GROUP BY(pe1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, pe2.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_pe2 pe2 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = pe2.codigo " +
                "WHERE pe2.fadn = '{0}' AND pe2.ano = '{1}' AND pe2.fkestado = '{2}' " +
                "GROUP BY(pe2.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c1_1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c1_1 c1_1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c1_1.codigo " +
                "WHERE c1_1.fadn = '{0}' AND c1_1.ano = '{1}' AND c1_1.fkestado = '{2}' " +
                "GROUP BY(c1_1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c2_1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c2_1 c2_1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_1.codigo " +
                "WHERE c2_1.fadn = '{0}' AND c2_1.ano = '{1}' AND c2_1.fkestado = '{2}' " +
                "GROUP BY(c2_1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c2_2.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c2_2 c2_2 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_2.codigo " +
                "WHERE c2_2.fadn = '{0}' AND c2_2.ano = '{1}' AND c2_2.fkestado = '{2}' " +
                "GROUP BY(c2_2.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c2_3.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c2_3 c2_3 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_3.codigo " +
                "WHERE c2_3.fadn = '{0}' AND c2_3.ano = '{1}' AND c2_3.fkestado = '{2}' " +
                "GROUP BY(c2_3.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c3_1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c3_1 c3_1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c3_1.codigo " +
                "WHERE c3_1.fadn = '{0}' AND c3_1.ano = '{1}' AND c3_1.fkestado = '{2}' " +
                "GROUP BY(c3_1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c3_2.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c3_2 c3_2 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c3_2.codigo " +
                "WHERE c3_2.fadn = '{0}' AND c3_2.ano = '{1}' AND c3_2.fkestado = '{2}' " +
                "GROUP BY(c3_2.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c4_1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c4_1 c4_1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_1.codigo " +
                "WHERE c4_1.fadn = '{0}' AND c4_1.ano = '{1}' AND c4_1.fkestado = '{2}' " +
                "GROUP BY(c4_1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c4_2.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c4_2 c4_2 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_2.codigo " +
                "WHERE c4_2.fadn = '{0}' AND c4_2.ano = '{1}' AND c4_2.fkestado = '{2}' " +
                "GROUP BY(c4_2.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c4_3.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c4_3 c4_3 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_3.codigo " +
                "WHERE c4_3.fadn = '{0}' AND c4_3.ano = '{1}' AND c4_3.fkestado = '{2}' " +
                "GROUP BY(c4_3.codigo)", fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT p3.idp3 AS numero, pe1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_pe1 pe1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = pe1.codigo " +
                "WHERE pe1.fadn = '{0}' AND pe1.ano = '{1}' AND pe1.fkestado IN (1,2) " +
                "GROUP BY(pe1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, pe2.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_pe2 pe2 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = pe2.codigo " +
                "WHERE pe2.fadn = '{0}' AND pe2.ano = '{1}' AND pe2.fkestado IN (1,2) " +
                "GROUP BY(pe2.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c1_1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c1_1 c1_1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c1_1.codigo " +
                "WHERE c1_1.fadn = '{0}' AND c1_1.ano = '{1}' AND c1_1.fkestado IN (1,2) " +
                "GROUP BY(c1_1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c2_1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c2_1 c2_1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_1.codigo " +
                "WHERE c2_1.fadn = '{0}' AND c2_1.ano = '{1}' AND c2_1.fkestado IN (1,2) " +
                "GROUP BY(c2_1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c2_2.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c2_2 c2_2 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_2.codigo " +
                "WHERE c2_2.fadn = '{0}' AND c2_2.ano = '{1}' AND c2_2.fkestado IN (1,2) " +
                "GROUP BY(c2_2.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c2_3.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c2_3 c2_3 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c2_3.codigo " +
                "WHERE c2_3.fadn = '{0}' AND c2_3.ano = '{1}' AND c2_3.fkestado IN (1,2) " +
                "GROUP BY(c2_3.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c3_1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c3_1 c3_1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c3_1.codigo " +
                "WHERE c3_1.fadn = '{0}' AND c3_1.ano = '{1}' AND c3_1.fkestado IN (1,2) " +
                "GROUP BY(c3_1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c3_2.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c3_2 c3_2 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c3_2.codigo " +
                "WHERE c3_2.fadn = '{0}' AND c3_2.ano = '{1}' AND c3_2.fkestado IN (1,2) " +
                "GROUP BY(c3_2.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c4_1.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c4_1 c4_1 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_1.codigo " +
                "WHERE c4_1.fadn = '{0}' AND c4_1.ano = '{1}' AND c4_1.fkestado IN (1,2) " +
                "GROUP BY(c4_1.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c4_2.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c4_2 c4_2 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_2.codigo " +
                "WHERE c4_2.fadn = '{0}' AND c4_2.ano = '{1}' AND c4_2.fkestado IN (1,2) " +
                "GROUP BY(c4_2.codigo) " +
                "UNION " +
                "SELECT p3.idp3 AS numero, c4_3.codigo AS codigo, p3.promocion AS promocion, " +
                "p3.programa AS programa, p3.actividad AS actividad, p3.subtotal AS subtotal, " +
                "p3.otra_fuente AS otra_fuente, p3.total AS total " +
                "FROM pat_c4_3 c4_3 " +
                "LEFT JOIN pat_p3 p3 ON p3.codigo = c4_3.codigo " +
                "WHERE c4_3.fadn = '{0}' AND c4_3.ano = '{1}' AND c4_3.fkestado IN (1,2) " +
                "GROUP BY(c4_3.codigo)", fadn, anio, estado);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable P3TotalRead(string fadn, string anio, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("SELECT idp3 AS numero, SUM(promocion) AS total1, SUM(programa) AS total2, SUM(actividad) AS total3, " +
                "SUM(subtotal) AS total4, SUM(otra_fuente) AS total5, SUM(total) AS total6 " +
                "FROM pat_p3 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';", fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT idp3 AS numero, SUM(promocion) AS total1, SUM(programa) AS total2, SUM(actividad) AS total3, " +
                "SUM(subtotal) AS total4, SUM(otra_fuente) AS total5, SUM(total) AS total6 " +
                "FROM pat_p3 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2);", fadn, anio, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable P3Create(ModeloP3 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_p3 (codigo, promocion, programa, actividad, subtotal, otra_fuente, total, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');",
            objCrear.codigo, objCrear.promocion, objCrear.programa, objCrear.actividad, objCrear.subtoltal, objCrear.otra_fuente, 
            objCrear.total, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean P3Update(ModeloP3 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c4_2 SET fkestado = '{0}' WHERE idc4_2 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_p3 SET promocion = '{0}', programa = '{1}', actividad = '{2}', " +
                "subtotal = '{3}', otra_fuente = '{4}', total = '{5}' WHERE idp3 = '{6}';", 
                o.promocion, o.programa, o.actividad, o.subtoltal, o.otra_fuente, o.total, id);
            }


            try
            {
                mysql.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
                cmd.ExecuteNonQuery();
                mysql.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int P3Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_p3 WHERE idp3 = '{0}'", id);
                mysql.AbrirConexion();
                MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
                MySqlDataReader buscar = consulta.ExecuteReader();
                using (buscar)
                {
                    while (buscar.Read())
                    {
                        if (!string.IsNullOrEmpty(buscar.GetString("fkestado")))
                        {
                            return int.Parse(buscar["fkestado"].ToString());
                        }
                    }
                }
                mysql.CerrarConexion();
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public bool P3Search(string codigo, string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_p3 " +
            "WHERE codigo = '{0}' AND fadn = '{1}' AND ano = '{2}';", codigo, fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("codigo")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public double VerificarMontoP1(string fadn, string anio, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT p1.col_uno AS total_p1 FROM pat_p1 p1 INNER JOIN admin_ingreso_corriente ic " +
                "ON ic.idingreso_corriente = p1.fkingreso_corriente " +
                "WHERE ic.fadn = '{0}' AND ic.nombre = 'De Gobierno Central (Aprobado en Asamblea de CDAG)' " +
                "AND p1.fadn = '{0}' AND p1.ano = '{1}' AND p1.fkestado = '{2}'; ", fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT p1.col_uno AS total_p1 FROM pat_p1 p1 INNER JOIN admin_ingreso_corriente ic " +
                "ON ic.idingreso_corriente = p1.fkingreso_corriente " +
                "WHERE ic.fadn = '{0}' AND ic.nombre = 'De Gobierno Central (Aprobado en Asamblea de CDAG)' " +
                "AND p1.fadn = '{0}' AND p1.ano = '{1}' AND p1.fkestado IN (1,2); ", fadn, anio, estado);
            }

            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    total_p1 = Convert.ToDouble(buscar["total_p1"].ToString());
                }
            }
            mysql.CerrarConexion();
            return total_p1;
        }

        public double VerificarMontoP3(string fadn, string anio, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT SUM(p3.total) AS total_p3 FROM pat_p3 p3 " +
                "WHERE p3.fadn = '{0}' AND p3.ano = '{1}' AND p3.fkestado = '{2}';", fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT SUM(p3.total) AS total_p3 FROM pat_p3 p3 " +
                "WHERE p3.fadn = '{0}' AND p3.ano = '{1}' AND p3.fkestado IN (1,2);", fadn, anio, estado);
            }

            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    total_p3 = Convert.ToDouble(buscar["total_p3"].ToString());
                }
            }
            mysql.CerrarConexion();
            return total_p3;
        }

        public double MontoP1_Igual_P3(string fadn, string anio, int estado)
        {
            double monto = VerificarMontoP1(fadn, anio, estado) - VerificarMontoP3(fadn, anio, estado);
            return monto;
        }
    }
}