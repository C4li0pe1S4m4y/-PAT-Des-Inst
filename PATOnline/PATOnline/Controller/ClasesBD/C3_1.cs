using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class C3_1
    {
        public string query = "";
        private int codigo;
        private double presupuesto;

        public DataTable C3_1Read(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT c3.idc3_1 AS numero, c3.codigo AS codigo, c3.nombre_competencia AS competencia, cla.nombre AS clasificacion, " +
                "n.nombre AS nivel, cat.nombre AS categoria, c3.edades AS edades, c3.fase_evento AS fase, " +
                "c3.resultado AS resultado, c3.registro AS registro, c3.inicio_dia AS inicio_dia, " +
                "c3.inicio_mes AS inicio_mes, c3.fin_dia AS fin_dia, c3.fin_mes AS fin_mes, " +
                "d.nombre AS departamento, c3.lugar AS lugar, c3.presupuesto AS presupuesto " +
                "FROM pat_c3_1 c3 " +
                "INNER JOIN admin_clasificacion cla ON cla.idclasificacion = c3.fkclasificacion " +
                "INNER JOIN admin_nivel n ON n.idnivel = c3.fknivel " +
                "INNER JOIN admin_categoria cat ON cat.idcategoria = c3.fkcategoria " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = c3.fkpais_departamento " +
                "WHERE c3.fadn = '{0}' AND c3.ano = '{1}' AND c3.fkestado = '{2}'; ", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT c3.idc3_1 AS numero, c3.codigo AS codigo, c3.nombre_competencia AS competencia, cla.nombre AS clasificacion, " +
                "n.nombre AS nivel, cat.nombre AS categoria, c3.edades AS edades, c3.fase_evento AS fase, " +
                "c3.resultado AS resultado, c3.registro AS registro, c3.inicio_dia AS inicio_dia, " +
                "c3.inicio_mes AS inicio_mes, c3.fin_dia AS fin_dia, c3.fin_mes AS fin_mes, " +
                "d.nombre AS departamento, c3.lugar AS lugar, c3.presupuesto AS presupuesto " +
                "FROM pat_c3_1 c3 " +
                "INNER JOIN admin_clasificacion cla ON cla.idclasificacion = c3.fkclasificacion " +
                "INNER JOIN admin_nivel n ON n.idnivel = c3.fknivel " +
                "INNER JOIN admin_categoria cat ON cat.idcategoria = c3.fkcategoria " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = c3.fkpais_departamento " +
                "WHERE c3.fadn = '{0}' AND c3.ano = '{1}' AND c3.fkestado IN (1,2); ", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C3_1TotalRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT c3.idc3_1 AS numero, SUM(c3.presupuesto) AS total " +
                "FROM pat_c3_1 c3 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}'; ", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT c3.idc3_1 AS numero, SUM(c3.presupuesto) AS total " +
                "FROM pat_c3_1 c3 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2); ", fadn, ano, estado);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C3_1Create(ModeloC3 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c3_1 (codigo, nombre_competencia, edades, fase_evento, resultado, " +
            "registro, inicio_dia, inicio_mes, fin_dia, fin_mes, lugar, presupuesto, fkclasificacion, " +
            "fknivel, fkcategoria, fkpais_departamento, fadn, ano, fkestado) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
            "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}');",
            objCrear.codigo, objCrear.nombre_competencia, objCrear.edades, objCrear.fase_evento, objCrear.resultado,
            objCrear.registro, objCrear.inicio_dia, objCrear.inicio_mes, objCrear.fin_dia, objCrear.fin_mes, objCrear.lugar, objCrear.presupuesto, objCrear.fkclasificacion,
            objCrear.fknivel, objCrear.fkcategoria, objCrear.fkdepartamento, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C3_1Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idc3_1, codigo, nombre_competencia, presupuesto, fkclasificacion, " +
            "fknivel, fkcategoria, fase_evento, resultado, edades, registro, inicio_dia, " +
            "inicio_mes, fin_dia, fin_mes, fkpais_departamento, lugar " +
            "FROM pat_c3_1 WHERE idc3_1 = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean C3_1Update(ModeloC3 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c3_1 SET fkestado = '{0}' WHERE idc3_1 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("UPDATE pat_c3_1 SET nombre_competencia = '{0}', presupuesto = '{1}', fkclasificacion = '{2}', " +
                "fknivel = '{3}', fkcategoria = '{4}', fase_evento = '{5}', resultado = '{6}', edades = '{7}', " +
                "registro = '{8}', inicio_dia = '{9}', inicio_mes = '{10}', fin_dia = '{11}', fin_mes = '{12}', " +
                "fkpais_departamento = '{13}', lugar = '{14}' WHERE idc3_1 = '{15}';", o.nombre_competencia, o.presupuesto, o.fkclasificacion,
                o.fknivel, o.fkcategoria, o.fase_evento, o.resultado, o.edades, o.registro, o.inicio_dia, o.inicio_mes, o.fin_dia, o.fin_mes,
                o.fkdepartamento, o.lugar, id);
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

        public int C3_1Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_c3_1 " +
                "WHERE idc3_1 = '{0}'", id);
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

        public int C3_1Codigo(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_c3_1 " +
            "WHERE idc3_1 = (SELECT MAX(idc3_1) FROM pat_c3_1 WHERE fadn = '{0}' AND ano = '{1}');", fadn, ano);
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

        public bool C3_1ExisteCodigo(string codigo, string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_c3_1 WHERE codigo='{0}' AND fadn='{1}' AND ano='{2}';", codigo, fadn, ano);
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

        public double C3_1Presupuesto(string fadn, string ano, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            if(estado > 1)
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c3 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' " +
                "AND f.nombre = 'C3.1 Sistema Competitivo Nacional' AND cpe.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c3 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' " +
                "AND f.nombre = 'C3.1 Sistema Competitivo Nacional' AND cpe.fkestado IN (1,2);", fadn, ano, estado);
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