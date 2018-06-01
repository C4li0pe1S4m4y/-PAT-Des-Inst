using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadIBL
    {
        public string query = "";

        public DataTable IBLRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
         
            query = String.Format("SELECT idinformacion as numero, introduccion as introduccion, marco_juridico as marco, afiliacion_organizacion as afiliacion " +
            "FROM pat_informacion WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';", fadn, ano, estado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable IBLSeleccionadoRead(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idinformacion as numero, introduccion as introduccion, marco_juridico as marco, afiliacion_organizacion as afiliacion " +
            "FROM pat_informacion WHERE idinformacion = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}