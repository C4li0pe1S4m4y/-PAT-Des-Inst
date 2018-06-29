using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class P1Ingresos
    {
        public string query = null;
        public string add = null;
        public DataTable ContaP1Read(string fadn, string anio, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("SELECT idp1 FROM pat_p1 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';",
                fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT idp1 FROM pat_p1 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2);",
                fadn, anio, estado);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable Part11Read(string fadn, string anio, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            for (int i = 1; i < 9; i++)
            {
                add = "";
                if (estado > 1)
                {
                    if (i == 1)
                    {
                        add = "WHERE fkestado = '{3}' AND idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' AND p.ano = '{2}' OR ic.fadn = 'Confederacion Deportiva Autonoma de Guatemala' OR idingreso_corriente = '{0}' OR idingreso_corriente = '1' GROUP BY (ic.codigo)";
                    }
                    if (i == 3 || i == 4 || i == 5 || i == 6 || i == 7)
                    {
                        add = "WHERE fkestado = '{3}' AND idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' AND p.ano = '{2}' OR ic.fadn = 'Confederacion Deportiva Autonoma de Guatemala' OR idingreso_corriente = '{0}' GROUP BY (ic.codigo)";
                    }
                    if (i == 8)
                    {
                        add = "WHERE fkestado = '{3}' AND idpadre = '2' AND subpadre = '{0}' AND ic.fadn = '{1}' AND p.ano = '{2}' OR ic.fadn = 'Confederacion Deportiva Autonoma de Guatemala' OR idingreso_corriente = '{0}' OR idingreso_corriente = '2' GROUP BY (ic.codigo)";
                    }
                }
                else
                {
                    if (i == 1)
                    {
                        add = "WHERE fkestado IN (1,2) AND idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' AND p.ano = '{2}' OR ic.fadn = 'Confederacion Deportiva Autonoma de Guatemala' OR idingreso_corriente = '{0}' OR idingreso_corriente = '1' GROUP BY (ic.codigo)";
                    }
                    if (i == 3 || i == 4 || i == 5 || i == 6 || i == 7)
                    {
                        add = "WHERE fkestado IN (1,2) AND idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' AND p.ano = '{2}' OR ic.fadn = 'Confederacion Deportiva Autonoma de Guatemala' OR idingreso_corriente = '{0}' GROUP BY (ic.codigo)";
                    }
                    if (i == 8)
                    {
                        add = "WHERE fkestado IN (1,2) AND idpadre = '2' AND subpadre = '{0}' AND ic.fadn = '{1}' AND p.ano = '{2}' OR ic.fadn = 'Confederacion Deportiva Autonoma de Guatemala' OR idingreso_corriente = '{0}' OR idingreso_corriente = '2' GROUP BY (ic.codigo)";
                    }
                }
                if (add != "")
                {
                    query = query + String.Format("SELECT p.idp1 AS idnumero2, ic.codigo AS codigo, " +
                    "ic.nombre AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, p.col_tres AS monto3 " +
                    "FROM pat_p1 p RIGHT JOIN admin_ingreso_corriente ic " +
                    "ON ic.idingreso_corriente = p.fkingreso_corriente " + add, i, fadn, anio, estado);
                }

                if (i == 8)
                {
                    mysql.AbrirConexion();
                    MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
                    consulta.Fill(dt);
                    mysql.CerrarConexion();
                    return dt;
                }
                if(i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7)
                {
                    query = String.Format(query + " UNION ALL ");
                }
            }
            return dt;
        }

        public DataTable TotalP1Read(string fadn, string anio, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT idp1 AS idnumero2, SUM(col_uno) AS total1, SUM(col_dos) AS total2, SUM(col_tres) AS total3 " +
                "FROM pat_p1 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';", fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT idp1 AS idnumero2, SUM(col_uno) AS total1, SUM(col_dos) AS total2, SUM(col_tres) AS total3 " +
                "FROM pat_p1 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2);", fadn, anio);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable P1Create(ModeloP1 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_p1 (col_uno, col_dos, col_tres, fkingreso_corriente, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'); ",
            objCrear.col1, objCrear.col2, objCrear.col3, objCrear.fkingreso, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable P1Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT p.idp1, ic1.idpadre, ic1.subpadre, p.fkingreso_corriente, " +
            "p.col_uno, p.col_dos, p.col_tres " +
            "FROM pat_p1 p " +
            "INNER JOIN admin_ingreso_corriente ic1 ON ic1.idingreso_corriente = p.fkingreso_corriente WHERE p.fkestado = '{0}'", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean P1Update(ModeloP1 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_p1 SET fkestado = '{0}' WHERE idp1 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_p1 SET col_uno='{0}', col_dos='{1}', col_tres='{2}', fkingreso_corriente='{3}' " +
                "WHERE idp1 = '{4}';",
                o.col1, o.col2, o.col3, o.fkingreso, id);
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

        public int P1EstadoSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_p1 " +
                "WHERE idp1 = '{0}'", id);
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

        public bool P1Search(int ingreso, string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT fkingreso_corriente FROM pat_p1 " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkingreso_corriente = '{2}';", fadn, anio, ingreso);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("fkingreso_corriente")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }      
    }
}