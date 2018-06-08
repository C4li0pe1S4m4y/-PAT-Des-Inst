using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class PuestoLogroAnalisisBrecha
    {

        public string query = "";

        public DataTable PuestoLogradoRead(string fadn, int posicion)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(posicion > 1)
            {
                query = String.Format("SELECT idanalisis_puesto AS numero, YEAR(anio) AS anio, puesto_obtenido AS puesto, puntos AS punteo, " +
                "observacion " +
                "FROM pat_analisis_puesto INNER JOIN admin_anio ON idanio = fkanio WHERE fadn = '{0}' AND fkestado = '{1}';", fadn, posicion);
            }
            else
            {
                query = String.Format("SELECT idanalisis_puesto AS numero, YEAR(anio) AS anio, puesto_obtenido AS puesto, puntos AS punteo, " +
                "observacion " +
                "FROM pat_analisis_puesto INNER JOIN admin_anio ON idanio = fkanio WHERE fadn = '{0}' AND fkestado IN(1,2);", fadn);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable BrechaRead(string fadn, string ano, int posicion)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (posicion > 1)
            {
                query = String.Format("SELECT nombre AS brecha, puntos AS punteo, puntos_obtenidos AS punteo_obtenido, " +
                "comparacion, observacion, idanalisis_brecha AS numero " +
                "FROM pat_analisis_brecha " +
                "INNER JOIN admin_brecha ON idbrecha = fkbrecha WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';", 
                fadn, ano, posicion);
            }
            else
            {
                query = String.Format("SELECT nombre AS brecha, puntos AS punteo, puntos_obtenidos AS punteo_obtenido, " +
                "comparacion, observacion, idanalisis_brecha AS numero " +
                "FROM pat_analisis_brecha " +
                "INNER JOIN admin_brecha ON idbrecha = fkbrecha WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2);",
                fadn, ano);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PuestoLogradoCreate(ModeloPuestoLogrado objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_analisis_puesto (puesto_obtenido, puntos, observacion, fkanio, fadn, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'); ",
            objCrear.puesto, objCrear.punteo, objCrear.observacion, objCrear.fkanio, objCrear.fadn, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable BrechaCreate(ModeloBrechaCategoria objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_analisis_brecha (puntos, puntos_obtenidos, comparacion, observacion, fkbrecha, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'); ",
            objCrear.punteo, objCrear.puntos, objCrear.comparacion, objCrear.observacion, objCrear.fkbrecha, objCrear.fadn, objCrear.anio, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable PuestoLogroSeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idanalisis_puesto AS numero, YEAR(anio) AS anio, puesto_obtenido AS puesto, puntos AS punteo, " +
                "observacion FROM pat_analisis_puesto INNER JOIN admin_anio ON idanio = fkanio WHERE idanalisis_puesto = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable BrechaSeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idanalisis_brecha AS numero, nombre AS brecha, puntos AS punteo, puntos_obtenidos AS punteo_obtenido, " +
            "comparacion, observacion " +
            "FROM pat_analisis_brecha " +
            "INNER JOIN admin_brecha ON idbrecha = fkbrecha WHERE idanalisis_brecha = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean PuestoLogroUpdate(ModeloPuestoLogrado o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_analisis_puesto SET fkestado = '{0}' WHERE idanalisis_puesto = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_analisis_puesto SET puesto_obtenido = '{0}', puntos = '{1}', " +
                "observacion = '{2}', fkanio = '{3}' WHERE idanalisis_puesto = '{4}'",
                o.puesto, o.punteo, o.observacion, o.fkanio, id);
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

        public Boolean BrechaUpdate(ModeloBrechaCategoria o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_analisis_brecha SET fkestado = '{0}' WHERE idanalisis_brecha = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("UPDATE pat_analisis_brecha SET puntos = '{0}', puntos_obtenidos = '{1}', " +
                "comparacion = '{2}', observacion = '{3}', fkbrecha = '{4}' " +
                "WHERE idanalisis_brecha = '{5}'",
                o.punteo, o.puntos, o.comparacion, o.observacion, o.fkbrecha, id);
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

        public int PuestoLogroSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_analisis_puesto " +
                "WHERE idanalisis_puesto = '{0}'", id);
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

        public int BrechaSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_analisis_brecha " +
                "WHERE idanalisis_brecha = '{0}'", id);
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