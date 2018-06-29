using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class PE1
    {
        public string query = "";
        private double presupuesto;
        private int codigo;

        public DataTable PE1Read(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("SELECT p.idpe1 AS numero, p.codigo AS codigo, a.nombre AS actividad, " +
                "p.resultado AS resultado, p.registro AS registro, p.inicio_dia AS inicio_dia, " +
                "p.inicio_mes AS inicio_mes, p.fin_dia AS fin_dia, p.fin_mes AS fin_mes, " +
                "d.nombre AS departamento, pa.nombre AS pais, p.lugar AS lugar, p.presupuesto AS presupuesto " +
                "FROM pat_pe1 p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = p.fkpais_departamento " +
                "INNER JOIN admin_pais_departamento pa ON pa.idpais_departamento = d.idpadre " +
                "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}'; ", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT p.idpe1 AS numero, p.codigo AS codigo, a.nombre AS actividad, " +
                "p.resultado AS resultado, p.registro AS registro, p.inicio_dia AS inicio_dia, " +
                "p.inicio_mes AS inicio_mes, p.fin_dia AS fin_dia, p.fin_mes AS fin_mes, " +
                "d.nombre AS departamento, pa.nombre AS pais, p.lugar AS lugar, p.presupuesto AS presupuesto " +
                "FROM pat_pe1 p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = p.fkpais_departamento " +
                "INNER JOIN admin_pais_departamento pa ON pa.idpais_departamento = d.idpadre " +
                "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2); ", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PE1TotalRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("SELECT p.idpe1 AS numero, SUM(p.presupuesto) AS total " +
                "FROM pat_pe1 p WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}'; ", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT p.idpe1 AS numero, SUM(p.presupuesto) AS total " +
                "FROM pat_pe1 p WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2); ", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PE1Create(ModeloPE1 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_pe1 (codigo, resultado, registro, inicio_dia, inicio_mes, fin_dia, " +
            "fin_mes, lugar, presupuesto, fkactividad_pat, fkpais_departamento, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}'); ",
            objCrear.codigo, objCrear.resultado, objCrear.registro, objCrear.i_dia, objCrear.i_mes, objCrear.f_dia,
            objCrear.f_mes, objCrear.lugar, objCrear.prespuesto, objCrear.fkactividad, objCrear.fkpais_departamento,
            objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PE1Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT pe1.idpe1, pe1.fkactividad_pat, pe1.codigo, pe1.resultado, pe1.registro, pe1.inicio_dia, " +
            "pe1.inicio_mes, pe1.fin_dia, pe1.fin_mes, d.idpadre, pe1.fkpais_departamento, pe1.lugar, pe1.presupuesto " +
            "FROM pat_pe1 pe1 " +
            "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = pe1.fkpais_departamento " +
            "WHERE pe1.idpe1 = '{0}'; ", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean PE1Update(ModeloPE1 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_pe1 SET fkestado = '{0}' WHERE idpe1 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_pe1 SET fkactividad_pat = '{0}', resultado = '{1}', registro = '{2}', " +
                "inicio_dia = '{3}', inicio_mes = '{4}', fin_dia = '{5}', fin_mes = '{6}', " +
                "fkpais_departamento = '{7}', lugar = '{8}', presupuesto = '{9}' WHERE idpe1 = '{10}';",
                o.fkactividad, o.resultado, o.registro, o.i_dia, o.i_mes, o.f_dia, o. f_mes, o.fkpais_departamento,
                o.lugar, o.prespuesto, id);
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

        public int PE1Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_pe1 " +
                "WHERE idpe1 = '{0}'", id);
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

        public int CodigoPE1(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_pe1 " +
            "WHERE idpe1 = (SELECT MAX(idpe1) FROM pat_pe1 WHERE fadn = '{0}' AND ano = '{1}');", fadn, ano);
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

        public bool ExisteCodigoPE1(string codigo, string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_pe1 WHERE codigo='{0}' AND fadn='{1}' AND ano='{2}';", codigo, fadn, ano);
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

        public double PE1Presupuesto(string fadn, string ano, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();

            if(estado > 1)
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_cpe cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' AND f.nombre = 'PE1. Gestión de la Alta Dirección' AND fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_cpe cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' AND f.nombre = 'PE1. Gestión de la Alta Dirección' AND fkestado IN (1,2);", fadn, ano, estado);
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