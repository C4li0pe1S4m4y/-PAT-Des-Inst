using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class C1_1
    {
        public string query = "";
        private int codigo;
        private double presupuesto;

        public DataTable C1_1Read(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT p.idc1_1 AS numero, p.codigo AS codigo, c.nombre AS categoria, p.descripcion AS descripcion," +
                "a.nombre AS actividad, p.resultado AS resultado, p.registro AS registro, p.inicio_dia AS inicio_dia, " +
                "p.inicio_mes AS inicio_mes, p.fin_dia AS fin_dia, p.fin_mes AS fin_mes, " +
                "d.nombre AS departamento, pa.nombre AS pais, p.lugar AS lugar, p.presupuesto AS presupuesto " +
                "FROM pat_c1_1 p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = p.fkpais_departamento " +
                "INNER JOIN admin_pais_departamento pa ON pa.idpais_departamento = d.idpadre " +
                "INNER JOIN admin_categoria c ON c.idcategoria = p.fkcategoria " +
                "WHERE p.fadn = '{0}' AND p.ano = {1} AND fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT p.idc1_1 AS numero, p.codigo AS codigo, c.nombre AS categoria, p.descripcion AS descripcion," +
                "a.nombre AS actividad, p.resultado AS resultado, p.registro AS registro, p.inicio_dia AS inicio_dia, " +
                "p.inicio_mes AS inicio_mes, p.fin_dia AS fin_dia, p.fin_mes AS fin_mes, " +
                "d.nombre AS departamento, pa.nombre AS pais, p.lugar AS lugar, p.presupuesto AS presupuesto " +
                "FROM pat_c1_1 p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = p.fkpais_departamento " +
                "INNER JOIN admin_pais_departamento pa ON pa.idpais_departamento = d.idpadre " +
                "INNER JOIN admin_categoria c ON c.idcategoria = p.fkcategoria " +
                "WHERE p.fadn = '{0}' AND p.ano = {1} AND fkestado IN (1,2);", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C1_1TotalRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SELECT p.idc1_1 AS numero, SUM(p.presupuesto) AS total " +
                "FROM pat_c1_1 p WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}'; ", fadn, ano, estado);                
            }
            else
            {
                query = String.Format("SELECT p.idc1_1 AS numero, SUM(p.presupuesto) AS total " +
                "FROM pat_c1_1 p WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2); ", fadn, ano, estado);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C1_1Create(ModeloC1 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c1_1 (codigo, resultado, descripcion, registro, inicio_dia, inicio_mes, fin_dia, " +
            "fin_mes, lugar, presupuesto, fkactividad_pat, fkpais_departamento, fkcategoria, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}'); ",
            objCrear.codigo, objCrear.resultado, objCrear.descripcion, objCrear.registro, objCrear.i_dia, objCrear.i_mes,
            objCrear.f_dia, objCrear.f_mes, objCrear.lugar, objCrear.prespuesto, objCrear.fkactividad,
            objCrear.fkpais_departamento, objCrear.fkcategoria, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C1_1Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT c.idc1_1, c.codigo, c.fkcategoria, c.fkactividad_pat, c.presupuesto, c.resultado, c.registro, " +
            "c.inicio_dia, c.inicio_mes, c.fin_dia, c.fin_mes, p.idpadre, c.fkpais_departamento, c.lugar, " +
            "c.descripcion " +
            "FROM pat_c1_1 c " +
            "INNER JOIN admin_pais_departamento p ON p.idpais_departamento = c.fkpais_departamento " +
            "WHERE c.idc1_1 = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean C1_1Update(ModeloC1 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c1_1 SET fkestado = '{0}' WHERE idc1_1 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c1_1 SET c.fkcategoria = '{0}', c.fkactividad_pat = '{1}', c.presupuesto = '{2}', " +
                "c.resultado = '{3}', c.registro = '{4}', c.inicio_dia = '{5}', c.inicio_mes = '{6}', " +
                "c.fin_dia = '{7}', c.fin_mes = '{8}', c.fkpais_departamento = '{9}', c.lugar = '{10}', " +
                "c.descripcion = '{11}' WHERE idc1_1 = '{12}';", o.fkcategoria, o.fkactividad, o.prespuesto,
                o.resultado, o.registro, o.i_dia, o.i_mes, o.f_dia, o.f_mes, o.fkpais_departamento, o.lugar,
                o.descripcion, id);
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

        public int C1_1Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_c1_1 " +
                "WHERE idc1_1 = '{0}'", id);
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

        public int C1_1Codigo(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_c1_1 " +
            "WHERE idc1_1 = (SELECT MAX(idc1_1) FROM pat_c1_1 WHERE fadn = '{0}' AND ano = '{1}');", fadn, ano);
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

        public bool C1_1ExisteCodigo(string codigo, string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_c1_1 WHERE codigo='{0}' AND fadn='{1}' AND ano='{2}';", codigo, fadn, ano);
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

        public double C1_1Presupuesto(string fadn, string ano, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            if(estado > 1)
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c1 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' AND f.idpadre = '2' AND cpe.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c1 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' AND f.idpadre = '2' AND cpe.fkestado IN (1,2);", fadn, ano, estado);
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