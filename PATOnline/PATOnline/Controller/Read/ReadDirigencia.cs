using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadDirigencia
    {
        public string query = "";
        public string add = "";
        public DataTable DirigenciaRead(int tipo, string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            add = " ;";
            
            query = String.Format("SELECT idasamblea_personal_fadn AS numero, c.nombre AS cargo, " +
            "CONCAT(df.primer_nombre, ' ', df.segundo_nombre, ' ', df.primer_apellido, ' ', df.segundo_apellido) AS nombre, " +
            "CONCAT(DAY(df.inicio_cargo), '/', MONTH(df.inicio_cargo), '/', YEAR(df.inicio_cargo)) AS inicio, " +
            "CONCAT(DAY(df.fin_cargo), '/', MONTH(df.fin_cargo), '/', YEAR(df.fin_cargo)) AS fin, " +
            "df.periodo AS periodo, df.fadn AS federacion " +
            "FROM pat_dirigencia_deportiva_fadn df " +
            "INNER JOIN admin_cargo c ON c.idcargo = df.fkcargo " +
            "INNER JOIN seg_estado e ON e.idestado = df.fkestado WHERE df.fktipo_personal_fadn = '{0}' AND df.fadn = '{1}' AND df.ano = '{2}' ORDER BY (c.nombre)", tipo, fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}