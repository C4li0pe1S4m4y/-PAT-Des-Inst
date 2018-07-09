using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class Arbitro
    {
        public string query = "";
        public DataTable ArbitroRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT a.idarbitro AS numero, CONCAT(a.primer_nombre,' ',a.segundo_nombre,' ',a.primer_apellido,' ',a.segundo_apellido) AS nombre, " +
                "a.nacionalidad AS nacionalidad, a.departamento_laboral AS departamento, n.nombre AS nivel, " +
                "a.observacion AS observacion FROM pat_arbitro a " +
                "INNER JOIN admin_nivel n ON n.idnivel = a.fknivel " +
                "WHERE a.fadn = '{0}' AND a.ano = '{1}' AND a.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT a.idarbitro AS numero, CONCAT(a.primer_nombre,' ',a.segundo_nombre,' ',a.primer_apellido,' ',a.segundo_apellido) AS nombre, " +
                "a.nacionalidad AS nacionalidad, a.departamento_laboral AS departamento, n.nombre AS nivel, " +
                "a.observacion AS observacion FROM pat_arbitro a " +
                "INNER JOIN admin_nivel n ON n.idnivel = a.fknivel " +
                "WHERE a.fadn = '{0}' AND a.ano = '{1}' AND a.fkestado IN (1,2);", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable ArbitroCreate(ModeloArbitro objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_arbitro (primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, " +
            "nacionalidad, departamento_laboral, fknivel, observacion, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');",
            objCrear.nombre1, objCrear.nombre2, objCrear.apellido1, objCrear.apellido2, objCrear.nacionalidad, objCrear.departamento,
            objCrear.fknivel, objCrear.observacion, objCrear.fadn, objCrear.anio, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable ArbitroSeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idarbitro, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, nacionalidad, " +
            "departamento_laboral, fknivel, observacion " +
            "FROM pat_arbitro WHERE idarbitro = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean ArbitroUpdate(ModeloArbitro o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_arbitro SET fkestado = '{0}' WHERE idarbitro = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_arbitro SET primer_nombre = '{0}', segundo_nombre = '{1}', primer_apellido = '{2}', " +
                "segundo_apellido = '{3}', nacionalidad = '{4}', departamento_laboral = '{5}', fknivel = '{6}', " +
                "observacion = '{7}' WHERE idarbitro = '{8}'; ",
                o.nombre1, o.nombre2, o.apellido1, o.apellido2, o.nacionalidad, o.departamento, o.fknivel,
                o.observacion, id);
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

        public int ArbitroEstado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_arbitro " +
                "WHERE idarbitro = '{0}'", id);
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