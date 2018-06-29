using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class C2_1
    {
        public string query = "";
        private int codigo;
        private double presupuesto;

        public DataTable C2_1Read(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SELECT p.idc2_1 AS numero, p.codigo AS codigo, a.nombre AS actividad, " +
                "p.descripcion AS descripcion, p.resultado AS resultado, p.registro AS registro, p.inicio_dia AS inicio_dia, " +
                "p.inicio_mes AS inicio_mes, p.fin_dia AS fin_dia, p.fin_mes AS fin_mes, " +
                "d.nombre AS departamento, pa.nombre AS pais, p.lugar AS lugar, p.presupuesto AS presupuesto " +
                "FROM pat_c2_1 p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = p.fkpais_departamento " +
                "INNER JOIN admin_pais_departamento pa ON pa.idpais_departamento = d.idpadre " +
                "WHERE p.fadn = '{0}' AND p.ano = '{1}' AND p.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT p.idc2_1 AS numero, p.codigo AS codigo, a.nombre AS actividad, " +
                "p.descripcion AS descripcion, p.resultado AS resultado, p.registro AS registro, p.inicio_dia AS inicio_dia, " +
                "p.inicio_mes AS inicio_mes, p.fin_dia AS fin_dia, p.fin_mes AS fin_mes, " +
                "d.nombre AS departamento, pa.nombre AS pais, p.lugar AS lugar, p.presupuesto AS presupuesto " +
                "FROM pat_c2_1 p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = p.fkpais_departamento " +
                "INNER JOIN admin_pais_departamento pa ON pa.idpais_departamento = d.idpadre " +
                "WHERE p.fadn = '{0}' AND p.ano = '{1}' AND p.fkestado IN (1,2);", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C2_1TotalRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SELECT p.idc2_1 AS numero, SUM(p.presupuesto) AS total " +
                "FROM pat_c2_1 p WHERE p.fadn = '{0}' AND p.ano = '{1}' AND p.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT p.idc2_1 AS numero, SUM(p.presupuesto) AS total " +
                "FROM pat_c2_1 p WHERE p.fadn = '{0}' AND p.ano = '{1}' AND p.fkestado IN (1,2);", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C2_1Create(ModeloC1 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c2_1 (codigo, resultado, descripcion, registro, inicio_dia, inicio_mes, fin_dia, " +
            "fin_mes, lugar, presupuesto, fkactividad_pat, fkpais_departamento, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}'); ",
            objCrear.codigo, objCrear.resultado, objCrear.descripcion, objCrear.registro, objCrear.i_dia, objCrear.i_mes,
            objCrear.f_dia, objCrear.f_mes, objCrear.lugar, objCrear.prespuesto, objCrear.fkactividad,
            objCrear.fkpais_departamento, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C2_1Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT c.idc2_1, c.codigo, c.fkactividad_pat, c.presupuesto, c.resultado, c.registro, " +
            "c.inicio_dia, c.inicio_mes, c.fin_dia, c.fin_mes, p.idpadre, c.fkpais_departamento, " +
            "c.lugar, c.descripcion " +
            "FROM pat_c2_1 c " +
            "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = c.fkpais_departamento " +
            "WHERE c.idc2_1 = '{0}'; ", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean C2_1Update(ModeloC1 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c2_1 SET fkestado = '{0}' WHERE idc2_1 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c2_1 c SET c.fkactividad_pat = '{0}', c.presupuesto = '{1}', " +
                "c.resultado = '{2}', c.registro = '{3}', c.inicio_dia = '{4}', " +
                "c.inicio_mes = '{5}', c.fin_dia = '{6}', c.fin_mes = '{7}', " +
                "c.fkpais_departamento = '{8}', c.lugar = '{9}', c.descripcion = '{10}' " +
                "WHERE c.idc2_1 = '{11}';", o.fkactividad, o.prespuesto, o.resultado, o.registro,
                o.i_dia, o.i_mes, o.f_dia, o.f_mes, o.fkpais_departamento, o.lugar, o.descripcion, id);
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

        public int C2_1Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_c2_1 " +
                "WHERE idc2_1 = '{0}'", id);
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

        public int C2_1Codigo(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_c2_1 " +
            "WHERE idc2_1 = (SELECT MAX(idc2_1) FROM pat_c2_1 WHERE fadn = '{0}' AND ano = '{1}');", fadn, ano);
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    codigo = int.Parse(reader["numero"].ToString());
                }
            }
            mysql.CerrarConexion();
            return codigo;
        }

        public bool C2_1ExisteCodigo(string codigo, string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_c2_1 WHERE codigo='{0}' AND fadn='{1}' AND ano='{2}';", codigo, fadn, ano);
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

        public double C2_1Presupuesto(string fadn, string ano, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            if(estado > 1)
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c2 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' " +
                "AND f.nombre = 'C2.1 Actividad de Fortalecimiento al Deporte Federado' AND cpe.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c2 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' " +
                "AND f.nombre = 'C2.1 Actividad de Fortalecimiento al Deporte Federado' AND cpe.fkestado IN (1,2);", fadn, ano, estado);
            }

            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                presupuesto = double.Parse(reader["numero"].ToString());
            }
            else
            {
                presupuesto = 0;
            }
            mysql.CerrarConexion();
            return presupuesto;
        }
    }
}