using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class C4_1
    {
        public string query = "";
        private int codigo;
        private double presupuesto;

        public DataTable C4_1Read(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT c4.idc4_1 AS numero, c4.codigo AS codigo, act.nombre AS actividad, " +
                "c4.descripcion AS descripcion, c4.objetivo AS objetivo, ep.nombre AS etapa, " +
                "c4.dirigido AS dirigido, c4.linea AS linea, c.nombre AS categoria, " +
                "c4.registro AS registro, c4.inicio_dia AS inicio_dia, c4.inicio_mes AS inicio_mes, " +
                "c4.fin_dia AS fin_dia, c4.fin_mes AS fin_mes, d.nombre AS departamento, " +
                "p.nombre AS pais, c4.lugar AS lugar, c4.presupuesto AS presupuesto " +
                "FROM pat_c4_1 c4 INNER JOIN admin_actividad_pat act ON act.idactividad_pat = c4.fkactividad " +
                "INNER JOIN admin_etapa_preparacion ep ON ep.idetapa_preparacion = c4.fketapa_preparacion " +
                "INNER JOIN admin_categoria c ON c.idcategoria = c4.fkcategoria " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = c4.fkpais_departamento " +
                "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = d.idpadre " +
                "WHERE c4.fadn = '{0}' AND c4.ano = '{1}' AND c4.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT c4.idc4_1 AS numero, c4.codigo AS codigo, act.nombre AS actividad, " +
                "c4.descripcion AS descripcion, c4.objetivo AS objetivo, ep.nombre AS etapa, " +
                "c4.dirigido AS dirigido, c4.linea AS linea, c.nombre AS categoria, " +
                "c4.registro AS registro, c4.inicio_dia AS inicio_dia, c4.inicio_mes AS inicio_mes, " +
                "c4.fin_dia AS fin_dia, c4.fin_mes AS fin_mes, d.nombre AS departamento, " +
                "p.nombre AS pais, c4.lugar AS lugar, c4.presupuesto AS presupuesto " +
                "FROM pat_c4_1 c4 INNER JOIN admin_actividad_pat act ON act.idactividad_pat = c4.fkactividad " +
                "INNER JOIN admin_etapa_preparacion ep ON ep.idetapa_preparacion = c4.fketapa_preparacion " +
                "INNER JOIN admin_categoria c ON c.idcategoria = c4.fkcategoria " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = c4.fkpais_departamento " +
                "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = d.idpadre " +
                "WHERE c4.fadn = '{0}' AND c4.ano = '{1}' AND c4.fkestado IN (1,2);", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_1TotalRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT c4.idc4_1 AS numero, SUM(c4.presupuesto) AS total " +
                "FROM pat_c4_1 c4 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}'; ", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT c4.idc4_1 AS numero, SUM(c4.presupuesto) AS total " +
                "FROM pat_c4_1 c4 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2); ", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_1Create(ModeloC4 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c4_1 (codigo, fkactividad, descripcion, objetivo, fketapa_preparacion, " +
            "dirigido, linea, fkcategoria, registro, inicio_dia, inicio_mes, fin_dia, fin_mes, " +
            "fkpais_departamento, lugar, presupuesto, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
            "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}');",
            objCrear.codigo, objCrear.fkactividad, objCrear.descripcion, objCrear.objetivo, objCrear.fketapa_prepacion,
            objCrear.dirigido, objCrear.linea, objCrear.fkcategoria, objCrear.registro, objCrear.inicio_dia, objCrear.inicio_mes, objCrear.fin_dia, objCrear.fin_mes,
            objCrear.fkpais_departamento, objCrear.lugar, objCrear.presupuesto, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_1Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT c.idc4_1, c.codigo, c.fkactividad, c.objetivo, c.presupuesto, c.fketapa_preparacion, " +
            "c.fkcategoria, c.dirigido, c.registro, c.linea, c.inicio_dia, c.inicio_mes, c.fin_dia, " +
            "c.fin_mes, p.idpadre, c.fkpais_departamento, c.lugar, c.descripcion " +
            "FROM pat_c4_1 c " +
            "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = c.fkpais_departamento " +
            "WHERE c.idc4_1 = '{0}'", id);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean C4_1Update(ModeloC4 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c4_1 SET fkestado = '{0}' WHERE idc4_1 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c4_1 c SET c.fkactividad = '{0}', c.objetivo = '{1}', c.presupuesto = '{2}', " +
                "c.fketapa_preparacion = '{3}', c.fkcategoria = '{4}', c.dirigido = '{5}', c.registro = '{6}', " +
                "c.linea = '{7}', c.inicio_dia = '{8}', c.inicio_mes = '{9}', c.fin_dia = '{10}', c.fin_mes = '{11}', " +
                "c.fkpais_departamento = '{12}', c.lugar = '{13}' WHERE c.idc4_1 = '{14}'; ", o.fkactividad, o.objetivo, o.presupuesto,
                o.fketapa_prepacion, o.fkcategoria, o.dirigido, o.registro, o.linea, o.inicio_dia, o.inicio_mes, o.fin_dia, o.fin_mes,
                o.fkpais_departamento, o.lugar, id);
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

        public int C4_1Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_c4_1 " +
                "WHERE idc4_1 = '{0}'", id);
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

        public int C4_1Codigo(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_c4_1 " +
            "WHERE idc4_1 = (SELECT MAX(idc4_1) FROM pat_c4_1 WHERE fadn = '{0}' AND ano = '{1}');", fadn, ano);
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

        public bool C4_1ExisteCodigo(string codigo, string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_c4_1 WHERE codigo='{0}' AND fadn='{1}' AND ano='{2}';", codigo, fadn, ano);
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

        public double C4_1Presupuesto(string fadn, string ano, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            if (estado > 1)
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c4 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' AND cpe.fkestado = '{2}' " +
                "AND f.nombre = 'C4.1 Control, Evaluación y Análisis de Procesos Deportivos';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c4 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' AND cpe.fkestado IN (1,2) " +
                "AND f.nombre = 'C4.1 Control, Evaluación y Análisis de Procesos Deportivos';", fadn, ano, estado);
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