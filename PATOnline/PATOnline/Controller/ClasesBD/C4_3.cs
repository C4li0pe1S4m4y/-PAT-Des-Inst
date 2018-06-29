using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class C4_3
    {
        public string query = "";
        private int codigo;
        private double presupuesto;

        public DataTable C4_3Read(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT c4.idc4_3 AS numero, c4.codigo AS codigo,  c4.competencia AS competencia, " +
                "c.nombre AS clasificacion, n.nombre AS nivel, cat.nombre AS categoria, c4.edades AS edades, " +
                "c4.linea AS linea, c4.resultado AS resultado, c4.registro AS registro, " +
                "c4.inicio_dia AS inicio_dia, c4.inicio_mes AS inicio_mes, c4.fin_dia AS fin_dia, " +
                "c4.fin_mes AS fin_mes, p.nombre AS pais, c4.lugar AS lugar, c4.presupuesto AS presupuesto " +
                "FROM pat_c4_3 c4 INNER JOIN admin_clasificacion c ON c.idclasificacion = c4.fkclasificacion " +
                "INNER JOIN admin_nivel n ON n.idnivel = c4.fknivel " +
                "INNER JOIN admin_categoria cat ON cat.idcategoria = c4.fkcategoria " +
                "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = c4.fkpais_departamento " +
                "WHERE c4.fadn = '{0}' AND c4.ano = '{1}' AND c4.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT c4.idc4_3 AS numero, c4.codigo AS codigo,  c4.competencia AS competencia, " +
                "c.nombre AS clasificacion, n.nombre AS nivel, cat.nombre AS categoria, c4.edades AS edades, " +
                "c4.linea AS linea, c4.resultado AS resultado, c4.registro AS registro, " +
                "c4.inicio_dia AS inicio_dia, c4.inicio_mes AS inicio_mes, c4.fin_dia AS fin_dia, " +
                "c4.fin_mes AS fin_mes, p.nombre AS pais, c4.lugar AS lugar, c4.presupuesto AS presupuesto " +
                "FROM pat_c4_3 c4 INNER JOIN admin_clasificacion c ON c.idclasificacion = c4.fkclasificacion " +
                "INNER JOIN admin_nivel n ON n.idnivel = c4.fknivel " +
                "INNER JOIN admin_categoria cat ON cat.idcategoria = c4.fkcategoria " +
                "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = c4.fkpais_departamento " +
                "WHERE c4.fadn = '{0}' AND c4.ano = '{1}' AND c4.fkestado IN (1,2);", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_3TotalRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT c4.idc4_3 AS numero, SUM(c4.presupuesto) AS total " +
                "FROM pat_c4_3 c4 WHERE fadn = '{0}' AND ano = '{1}' AND c4.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT c4.idc4_3 AS numero, SUM(c4.presupuesto) AS total " +
                "FROM pat_c4_3 c4 WHERE fadn = '{0}' AND ano = '{1}' AND c4.fkestado IN (1,2);", fadn, ano, estado);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_3Create(ModeloC4 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c4_3 (codigo, competencia, fkclasificacion, fknivel, fkcategoria, edades, " +
            "linea, resultado, registro, inicio_dia, inicio_mes, fin_dia, fin_mes, fkpais_departamento, " +
            "lugar, presupuesto, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
            "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');",
            objCrear.codigo, objCrear.competicion, objCrear.fkclasificacion, objCrear.fknivel, objCrear.fkcategoria, objCrear.edades,
            objCrear.linea, objCrear.resultado, objCrear.registro, objCrear.inicio_dia, objCrear.inicio_mes, objCrear.fin_dia, objCrear.fin_mes, objCrear.fkpais_departamento,
            objCrear.lugar, objCrear.presupuesto, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C4_3Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT c.idc4_3, c.codigo, c.competencia, c.fkclasificacion, c.presupuesto, c.fknivel, " +
            "c.fkcategoria, c.edades, c.linea, c.resultado, c.registro, c.inicio_dia, c.inicio_mes, " +
            "c.fin_dia, c.fin_mes, c.fkpais_departamento, c.lugar " +
            "FROM pat_c4_3 c WHERE c.idc4_3 = '{0}';", id);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean C4_3Update(ModeloC4 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c4_3 SET fkestado = '{0}' WHERE idc4_3 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c4_3 c SET c.competencia = '{0}', c.fkclasificacion = '{1}', " +
                "c.presupuesto = '{2}', c.fknivel = '{3}', c.fkcategoria = '{4}', " +
                "c.edades = '{5}', c.linea = '{6}', c.resultado = '{7}', c.registro = '{8}', " +
                "c.inicio_dia = '{9}', c.inicio_mes = '{10}', c.fin_dia = '{11}', c.fin_mes = '{12}', " +
                "c.fkpais_departamento = '{13}', c.lugar = '{14}' WHERE c.idc4_3 = '{15}';", 
                o.competicion, o.fkclasificacion, o.presupuesto, o.fknivel, o.fkcategoria, o.edades,
                o.linea, o.resultado, o.registro, o.inicio_dia, o.inicio_mes, o.fin_dia, o.fin_mes,
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

        public int C4_3Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_c4_3 " +
                "WHERE idc4_3 = '{0}'", id);
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

        public int C4_3Codigo(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_c4_3 " +
            "WHERE idc4_3 = (SELECT MAX(idc4_3) FROM pat_c4_3 WHERE fadn = '{0}' AND ano = '{1}');", fadn, ano);
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

        public bool C4_3ExisteCodigo(string codigo, string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_c4_3 WHERE codigo='{0}' AND fadn='{1}' AND ano='{2}';", codigo, fadn, ano);
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

        public double C4_3Presupuesto(string fadn, string ano, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            if (estado > 1)
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c4 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' AND cpe.fkestado = '{2}' " +
                "AND f.nombre = 'C4.3 Alcance Competitivo Nacional';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c4 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' AND cpe.fkestado IN (1,2) " +
                "AND f.nombre = 'C4.3 Alcance Competitivo Nacional';", fadn, ano, estado);
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