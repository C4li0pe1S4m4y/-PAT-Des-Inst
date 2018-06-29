using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class C3_2
    {
        public string query = "";
        private int codigo;
        private double presupuesto;

        public DataTable C3_2Read(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SELECT c3.idc3_2 AS numero, c3.codigo AS codigo, act.nombre AS actividad, cat.nombre AS categoria, " +
                "c3.edades AS edades, c3.masculino AS mas, c3.femenino AS fem, c3.total_f_m AS total, " +
                "c3.registro AS registro, c3.inicio_dia AS inicio_dia, c3.inicio_mes AS inicio_mes, " +
                "c3.fin_dia AS fin_dia, c3.fin_mes AS fin_mes, d.nombre AS departamento, " +
                "c3.lugar AS lugar, c3.presupuesto AS presupuesto " +
                "FROM pat_c3_2 c3 " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = c3.fkdepartamento " +
                "INNER JOIN admin_actividad_pat act ON act.idactividad_pat = c3.fkactividad " +
                "INNER JOIN admin_categoria cat ON cat.idcategoria = c3.fkcategoria " +
                "WHERE c3.fadn = '{0}' AND c3.ano = '{1}' AND c3.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT c3.idc3_2 AS numero, c3.codigo AS codigo, act.nombre AS actividad, cat.nombre AS categoria, " +
                "c3.edades AS edades, c3.masculino AS mas, c3.femenino AS fem, c3.total_f_m AS total, " +
                "c3.registro AS registro, c3.inicio_dia AS inicio_dia, c3.inicio_mes AS inicio_mes, " +
                "c3.fin_dia AS fin_dia, c3.fin_mes AS fin_mes, d.nombre AS departamento, " +
                "c3.lugar AS lugar, c3.presupuesto AS presupuesto " +
                "FROM pat_c3_2 c3 " +
                "INNER JOIN admin_pais_departamento d ON d.idpais_departamento = c3.fkdepartamento " +
                "INNER JOIN admin_actividad_pat act ON act.idactividad_pat = c3.fkactividad " +
                "INNER JOIN admin_categoria cat ON cat.idcategoria = c3.fkcategoria " +
                "WHERE c3.fadn = '{0}' AND c3.ano = '{1}' AND c3.fkestado IN (1,2);", fadn, ano, estado);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C3_2TotalRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT c3.idc3_2 AS numero, SUM(c3.presupuesto) AS total " +
                "FROM pat_c3_2 c3 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}'; ", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT c3.idc3_2 AS numero, SUM(c3.presupuesto) AS total " +
                "FROM pat_c3_2 c3 WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2); ", fadn, ano, estado);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C3_2Create(ModeloC3 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c3_2 (codigo, edades, masculino, femenino, total_f_m, registro, " +
            "inicio_dia, inicio_mes, fin_dia, fin_mes, fkdepartamento, lugar, presupuesto, " +
            "fkactividad, fkcategoria, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
            "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');",
            objCrear.codigo, objCrear.edades, objCrear.masculino, objCrear.femenino, objCrear.total, objCrear.registro,
            objCrear.inicio_dia, objCrear.inicio_mes, objCrear.fin_dia, objCrear.fin_mes, objCrear.fkdepartamento, objCrear.lugar, objCrear.presupuesto,
            objCrear.fkactividad, objCrear.fkcategoria, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable C3_2Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idc3_2, codigo, fkactividad, fkcategoria, presupuesto, edades, masculino, femenino, " +
            "registro, inicio_dia, inicio_mes, fin_dia, fin_mes, fkdepartamento, lugar " +
            "FROM pat_c3_2 WHERE idc3_2 = '{0}'; ", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean C3_2Update(ModeloC3 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_c3_2 SET fkestado = '{0}' WHERE idc3_2 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("UPDATE pat_c3_2 SET fkactividad = '{0}', fkcategoria = '{1}', presupuesto = '{2}', " +
                "edades = '{3}', masculino = '{4}', femenino = '{5}', registro = '{6}', " +
                "inicio_dia = '{7}', inicio_mes = '{8}', fin_dia = '{9}', fin_mes = '{10}', " +
                "fkdepartamento = '{11}', lugar = '{12}' WHERE idc3_2 = '{13}';", o.fkactividad, o.fkcategoria, o.presupuesto,
                o.edades, o.masculino, o.femenino, o.registro, o.inicio_dia, o.inicio_mes, o.fin_dia, o.fin_mes,
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

        public int C3_2Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_c3_2 " +
                "WHERE idc3_2 = '{0}'", id);
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

        public int C3_2Codigo(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_c3_2 " +
            "WHERE idc3_2 = (SELECT MAX(idc3_2) FROM pat_c3_2 WHERE fadn = '{0}' AND ano = '{1}');", fadn, ano);
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

        public bool C3_2ExisteCodigo(string codigo, string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_c3_2 WHERE codigo='{0}' AND fadn='{1}' AND ano='{2}';", codigo, fadn, ano);
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

        public double C3_2Presupuesto(string fadn, string ano, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            if(estado > 1)
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c3 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' " +
                "AND f.nombre = 'C3.2 Sistema de Juegos Deportivos Nacionales' AND cpe.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c3 cpe " +
                "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' " +
                "AND f.nombre = 'C3.2 Sistema de Juegos Deportivos Nacionales' AND cpe.fkestado IN (1,2);", fadn, ano, estado);
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