using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class ResultadosPotencias
    {
        public string query = "";
        public DataTable ResultadoRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("SELECT r.idresultado_dih AS numero, n.nombre AS nivel, r.nombre AS competencia, " +
                "r.sede AS sed, r.fecha AS fecha_resultado, " +
                "c.nombre AS categoria, r.resultado AS resultado_obtenido, r.observacion AS observacion " +
                "FROM pat_resultado_dih r " +
                "INNER JOIN admin_nivel n ON n.idnivel = r.fknivel " +
                "INNER JOIN admin_categoria c ON c.idcategoria = r.fkcategoria " +
                "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT r.idresultado_dih AS numero, n.nombre AS nivel, r.nombre AS competencia, " +
                "r.sede AS sed, r.fecha AS fecha_resultado, " +
                "c.nombre AS categoria, r.resultado AS resultado_obtenido, r.observacion AS observacion " +
                "FROM pat_resultado_dih r " +
                "INNER JOIN admin_nivel n ON n.idnivel = r.fknivel " +
                "INNER JOIN admin_categoria c ON c.idcategoria = r.fkcategoria " +
                "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2);", fadn, ano);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PotenciaRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("SELECT p.idpotencia_ag AS numero, n.nombre AS nivel, p.primera_potencia AS primera, " +
                "p.segunda_potencia AS segunda, p.tercera_potencia AS tercera, p.posicion_guatemala AS posicion " +
                "FROM pat_potencia_ag p " +
                "INNER JOIN admin_nivel n ON n.idnivel = p.fknivel " +
                "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT p.idpotencia_ag AS numero, n.nombre AS nivel, p.primera_potencia AS primera, " +
                "p.segunda_potencia AS segunda, p.tercera_potencia AS tercera, p.posicion_guatemala AS posicion " +
                "FROM pat_potencia_ag p " +
                "INNER JOIN admin_nivel n ON n.idnivel = p.fknivel " +
                "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2);", fadn, ano);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable ResultadoCreate(ModeloResultado objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_resultado_dih (nombre, sede, fecha, resultado, observacion, fknivel, fkcategoria, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', STR_TO_DATE('{2}', '%Y-%m-%d'), '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}'); ",
            objCrear.nombre, objCrear.sede, objCrear.fecha, objCrear.resultado, objCrear.observacion, objCrear.fknivel, 
            objCrear.fkcategoria, objCrear.fadn, objCrear.anio, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PotenciaCreate(ModeloPotencia objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_potencia_ag (primera_potencia, segunda_potencia, tercera_potencia, posicion_guatemala, fknivel, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');",
            objCrear.primera, objCrear.segunda, objCrear.tercera, objCrear.potencia, 
            objCrear.fknivel, objCrear.fadn, objCrear.anio, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable ResultadoSeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT r.idresultado_dih AS numero, r.fknivel AS nivel, r.nombre AS competencia, " +
                "r.sede AS sed, r.fecha AS fecha_resultado, " +
                "r.fkcategoria AS categoria, r.resultado AS resultado_obtenido, r.observacion AS observar " +
                "FROM pat_resultado_dih r " +
                "WHERE r.idresultado_dih = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PotenciaSeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT p.idpotencia_ag AS numero, p.fknivel AS nivel, p.primera_potencia AS primera, " +
                "p.segunda_potencia AS segunda, p.tercera_potencia AS tercera, p.posicion_guatemala AS posicion " +
                "FROM pat_potencia_ag p " +
                "WHERE p.idpotencia_ag = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean ResultadoUpdate(ModeloResultado o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_resultado_dih SET fkestado = '{0}' WHERE idresultado_dih = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_resultado_dih SET nombre = '{0}', sede = '{1}', fecha = '{2}', " +
                "resultado = '{3}', fknivel = '{4}', fkcategoria = '{5}' " +
                "WHERE idresultado_dih = '{6}'",
                o.nombre, o.sede, o.fecha, o.resultado, o.fknivel, o.fkcategoria, id);
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

        public Boolean PotenciaUpdate(ModeloPotencia o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_potencia_ag SET fkestado = '{0}' WHERE idpotencia_ag = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_potencia_ag SET primera_potencia = '{0}', segunda_potencia = '{1}', " +
                "tercera_potencia = '{2}', posicion_guatemala = '{3}', fknivel = '{4}' " +
                "WHERE idpotencia_ag = '{5}'",
                o.primera, o.segunda, o.tercera, o.potencia, o.fknivel, id);
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

        public int ResultadoSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_resultado_dih " +
                "WHERE idresultado_dih = '{0}'", id);
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

        public int PotenciaSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_potencia_ag " +
                "WHERE idpotencia_ag = '{0}'", id);
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
    }
}