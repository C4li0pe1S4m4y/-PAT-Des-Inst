using System;
using System.Data;
using MySql.Data.MySqlClient;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class DirigenciaDeportivas
    {
        public string query = "";
        public DataTable ComiteEjecutivoRead(string fadn)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT dbsecretaria.t.descripcion AS tipo, CONCAT(dbsecretaria.d.Nombres,' ',dbsecretaria.d.Apellidos) AS nombre, " +
            "CONCAT(DAY(dbsecretaria.c.Fecha_inicio), '/', MONTH(dbsecretaria.c.Fecha_inicio), '/', YEAR(dbsecretaria.c.Fecha_inicio)) AS posesion, " +
            "CONCAT(DAY(dbsecretaria.c.Fecha_final), '/', MONTH(dbsecretaria.c.Fecha_final), '/', YEAR(dbsecretaria.c.Fecha_final)) AS entrega, " +
            "dbsecretaria.c.Periodo AS periodo, dbsecretaria.f.nombre AS federacion " +
            "FROM dbsecretaria.sg_comite_ejecutivo c " +
            "INNER JOIN dbsecretaria.sg_dirigente d ON dbsecretaria.d.idDirigente = dbsecretaria.c.id_dirigente " +
            "INNER JOIN dbsecretaria.sg_fadn f ON dbsecretaria.f.id_fand = dbsecretaria.c.id_fadn " +
            "INNER JOIN dbsecretaria.sg_tipo_dirigente t ON dbsecretaria.t.idTipo_dirigente = dbsecretaria.d.Tipo_dirigente " +
            "WHERE dbsecretaria.c.Estado_Comite = 1 AND dbsecretaria.d.Estado = 'Activo' AND dbsecretaria.f.nombre = '{0}' ORDER BY (tipo)", fadn);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable DirigenciaRead(int tipo, string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT idasamblea_personal_fadn AS numero, c.nombre AS cargo, " +
                "CONCAT(df.primer_nombre, ' ', df.segundo_nombre, ' ', df.primer_apellido, ' ', df.segundo_apellido) AS nombre, " +
                "CONCAT(DAY(df.inicio_cargo), '/', MONTH(df.inicio_cargo), '/', YEAR(df.inicio_cargo)) AS inicio, " +
                "CONCAT(DAY(df.fin_cargo), '/', MONTH(df.fin_cargo), '/', YEAR(df.fin_cargo)) AS fin, " +
                "df.periodo AS periodo, df.fadn AS federacion " +
                "FROM pat_dirigencia_deportiva_fadn df " +
                "INNER JOIN admin_cargo c ON c.idcargo = df.fkcargo " +
                "WHERE df.fktipo_personal_fadn = '{0}' AND df.fadn = '{1}' AND df.ano = '{2}' AND df.fkestado = '{3}' ORDER BY (c.nombre)", tipo, fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT idasamblea_personal_fadn AS numero, c.nombre AS cargo, " +
                "CONCAT(df.primer_nombre, ' ', df.segundo_nombre, ' ', df.primer_apellido, ' ', df.segundo_apellido) AS nombre, " +
                "CONCAT(DAY(df.inicio_cargo), '/', MONTH(df.inicio_cargo), '/', YEAR(df.inicio_cargo)) AS inicio, " +
                "CONCAT(DAY(df.fin_cargo), '/', MONTH(df.fin_cargo), '/', YEAR(df.fin_cargo)) AS fin, " +
                "df.periodo AS periodo, df.fadn AS federacion " +
                "FROM pat_dirigencia_deportiva_fadn df " +
                "INNER JOIN admin_cargo c ON c.idcargo = df.fkcargo " +
                "WHERE df.fktipo_personal_fadn = '{0}' AND df.fadn = '{1}' AND df.ano = '{2}' AND df.fkestado IN (1,2) ORDER BY (c.nombre)", tipo, fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable DirigenciaCreate(ModeloDirigencia objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_dirigencia_deportiva_fadn " +
            "(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, inicio_cargo, fin_cargo, " +
            "periodo, fktipo_personal_fadn, fkcargo, fkestado, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', STR_TO_DATE('{4}', '%Y-%m-%d'), DATE_ADD('{5}', INTERVAL {6} DAY), " +
            "'{7}', '{8}', '{9}', '{10}', '{11}', '{12}'); ",
            objCrear.nombre1, objCrear.nombre2, objCrear.apellido1, objCrear.apellido2, objCrear.inicio, objCrear.inicio, objCrear.fin,
            objCrear.periodo, objCrear.fk_persona, objCrear.fk_cargo, objCrear.fk_estado, objCrear.fadn, objCrear.anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable SeleccionarDirigenciaDeportiva(int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT idasamblea_personal_fadn AS numero, c.nombre AS cargo, " +
            "df.primer_nombre AS numero1, df.segundo_nombre AS numero2, df.primer_apellido AS apellido1, df.segundo_apellido AS apellido2, " +
            "CONCAT(DAY(df.inicio_cargo), '/', MONTH(df.inicio_cargo), '/', YEAR(df.inicio_cargo)) AS inicio, " +
            "CONCAT(DAY(df.fin_cargo), '/', MONTH(df.fin_cargo), '/', YEAR(df.fin_cargo)) AS fin, " +
            "df.periodo AS periodo, df.fadn AS federacion " +
            "FROM pat_dirigencia_deportiva_fadn df " +
            "INNER JOIN admin_cargo c ON c.idcargo = df.fkcargo " +
            "WHERE df.idasamblea_personal_fadn = '{0}'", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public int DirigenciaDeportivaSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_dirigencia_deportiva_fadn " +
                "WHERE idasamblea_personal_fadn = '{0}'", id);
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

        public Boolean DirigenciaDeportivaUpdate(ModeloDirigencia objCrear, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("UPDATE pat_dirigencia_deportiva_fadn SET fkestado = '{0}' WHERE idasamblea_personal_fadn = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("UPDATE pat_dirigencia_deportiva_fadn SET primer_nombre = '{0}', segundo_nombre = '{1}', " +
                "primer_apellido = '{2}', segundo_apellido = '{3}', inicio_cargo = STR_TO_DATE('{4}', '%Y-%m-%d'), " +
                "fin_cargo = DATE_ADD('{5}', INTERVAL '{6}' DAY), periodo = '{7}', fktipo_personal_fadn = '{8}', " +
                "fkcargo = '{9}'  WHERE idasamblea_personal_fadn = '{11}'",
                objCrear.nombre1, objCrear.nombre2, objCrear.apellido1, objCrear.apellido2, objCrear.inicio, objCrear.inicio, objCrear.fin,
                objCrear.periodo, objCrear.fk_persona, objCrear.fk_cargo, id);
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
    }
}