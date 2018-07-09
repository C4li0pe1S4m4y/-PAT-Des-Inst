using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class Entrenador
    {
        public string query = "";
        public DataTable EntrenadorRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT e.identrenador AS numero, CONCAT(e.primer_nombre,' ',e.segundo_nombre,' ',e.primer_apellido,' ',e.segundo_apellido) AS nombre, " +
                "e.nacionalidad AS nacionalidad, e.departamento_laboral AS laboral, e.modalidad_deportiva AS modalidad, r.nombre AS responsanilidad, " +
                "e.categoria_edad AS categoria, l.nombre AS linea " +
                "FROM pat_entrenador e " +
                "INNER JOIN admin_responsabilidad_linea r ON r.idresponsabilidad_linea = e.fkresponsabilidad " +
                "INNER JOIN admin_responsabilidad_linea l ON l.idresponsabilidad_linea = e.fklinea " +
                "WHERE e.fadn = '{0}' AND e.ano = '{1}' AND e.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT e.identrenador AS numero, CONCAT(e.primer_nombre,' ',e.segundo_nombre,' ',e.primer_apellido,' ',e.segundo_apellido) AS nombre, " +
                "e.nacionalidad AS nacionalidad, e.departamento_laboral AS laboral, e.modalidad_deportiva AS modalidad, r.nombre AS responsanilidad, " +
                "e.categoria_edad AS categoria, l.nombre AS linea " +
                "FROM pat_entrenador e " +
                "INNER JOIN admin_responsabilidad_linea r ON r.idresponsabilidad_linea = e.fkresponsabilidad " +
                "INNER JOIN admin_responsabilidad_linea l ON l.idresponsabilidad_linea = e.fklinea " +
                "WHERE e.fadn = '{0}' AND e.ano = '{1}' AND e.fkestado IN (1,2);", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable EntrenadorCreate(ModeloEntrenador objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_entrenador (primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, " +
            "nacionalidad, departamento_laboral, modalidad_deportiva, categoria_edad, fkresponsabilidad, " +
            "fklinea, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');",
            objCrear.nombre1, objCrear.nombre2,objCrear.apellido1, objCrear.apellido2, objCrear.nacionalidad, objCrear.departamento_laboral,
            objCrear.modalidad, objCrear.categoria, objCrear.fkresponsabilidad, objCrear.fklinea, objCrear.fadn, objCrear.anion, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable EntrenadorSeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT identrenador, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, " +
            "nacionalidad, departamento_laboral, modalidad_deportiva, categoria_edad, fkresponsabilidad, fklinea " +
            "FROM pat_entrenador " +
            "WHERE identrenador = '{0}'; ", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean EntrenadorUpdate(ModeloEntrenador o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_entrenador SET fkestado = '{0}' WHERE identrenador = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_entrenador SET primer_nombre = '{0}', segundo_nombre = '{1}', primer_apellido = '{2}', " +
                "segundo_apellido = '{3}', nacionalidad = '{4}', departamento_laboral = '{5}', modalidad_deportiva = '{6}', " +
                "categoria_edad = '{7}', fkresponsabilidad = '{8}', fklinea = '{9}' WHERE identrenador = '{10}';",
                o.nombre1, o.nombre2, o.apellido1, o.apellido2, o.nacionalidad, o.departamento_laboral, o.modalidad, o.categoria,
                o.fkresponsabilidad, o.fklinea, id);
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

        public int EntrenadorEstado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_entrenador " +
                "WHERE identrenador = '{0}'", id);
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