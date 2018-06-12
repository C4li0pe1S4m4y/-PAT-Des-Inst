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
        public DataTable Part11Read(int id1, string fadn, string anio, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                if (id1 == 3)
                {
                    add = "WHERE idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' AND fkestado = '{2}' OR idingreso_corriente = '{0}' OR idingreso_corriente = '1' GROUP BY (ic.codigo);";
                }
                if (id1 >= 4 || id1 <= 7)
                {
                    add = "WHERE idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' AND fkestado = '{2}' OR idingreso_corriente = '{0}' GROUP BY (ic.codigo);";
                }
                if (id1 == 8)
                {
                    add = "WHERE idpadre = '2' AND subpadre = '{0}' AND ic.fadn = '{1}' AND fkestado = '{2}' OR idingreso_corriente = '{0}' OR idingreso_corriente = '2' GROUP BY (ic.codigo);";
                }
            }
            else
            {
                if (id1 == 3)
                {
                    add = "WHERE idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' AND fkestado IN (1,2) OR idingreso_corriente = '{0}' OR idingreso_corriente = '1' GROUP BY (ic.codigo);";
                }
                if (id1 >= 4 || id1 <= 7)
                {
                    add = "WHERE idpadre = '1' AND subpadre = '{0}' AND ic.fadn = '{1}' AND fkestado IN (1,2) OR idingreso_corriente = '{0}' GROUP BY (ic.codigo);";
                }
                if (id1 == 8)
                {
                    add = "WHERE idpadre = '2' AND subpadre = '{0}' AND ic.fadn = '{1}' AND fkestado IN (1,2) OR idingreso_corriente = '{0}' OR idingreso_corriente = '2' GROUP BY (ic.codigo);";
                }
            }
            query = String.Format("SELECT ic.idingreso_corriente AS idnumero2, ic.codigo AS codigo, " +
            "ic.nombre AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, p.col_tres AS monto3 " +
            "FROM pat_p1 p RIGHT JOIN admin_ingreso_corriente ic " +
            "ON ic.idingreso_corriente = p.fkingreso_corriente " + add, id1, fadn, estado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
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

            query = String.Format("SELECT idp1, col_uno, col_dos, col_tres, fkingreso_corriente  FROM pat_p1 " +
            "WHERE idp1 = '{0}'; ", id);
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