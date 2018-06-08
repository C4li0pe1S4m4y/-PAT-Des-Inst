using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace PATOnline.Controller.ClasesBD
{
    public class graficasPAT
    {
        public string query = "";
        public DataTable graficaAprobadoRechazadoIntroducccion(string user, string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT 'INTRODUCCION', " +
            "COUNT((SELECT oa.idobservacion_acompaniamiento FROM seg_usuario u " +
            "INNER JOIN admin_asignar_fadn af ON af.fkusuario = u.idusuario " +
            "INNER JOIN pat_informacion i ON i.fadn = af.nombre_fadn " +
            "INNER JOIN seg_observacion_acompaniamiento oa ON oa.fkinformacion = i.idinformacion " +
            "WHERE u.username = '{0}' AND af.nombre_fadn = '{1}' " +
            "AND i.ano = '{2}' AND oa.observacion = '')) as Aprobado, " +
            "COUNT((SELECT oa.idobservacion_acompaniamiento FROM seg_usuario u " +
            "INNER JOIN admin_asignar_fadn af ON af.fkusuario = u.idusuario " +
            "INNER JOIN pat_informacion i ON i.fadn = af.nombre_fadn " +
            "INNER JOIN seg_observacion_acompaniamiento oa ON oa.fkinformacion = i.idinformacion " +
            "WHERE u.username = '{0}' AND af.nombre_fadn = '{1}' " +
            "AND i.ano = '{2}' AND oa.observacion != '')) as Rechazado " +
            "FROM seg_observacion_acompaniamiento;", user, fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}