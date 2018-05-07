using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadPuestoLogrado
    {
        public string query = "";
        public string add = "";
        public DataTable PuestoLogradoRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if (fadn == "Confederación Deportiva Autónoma de Guatemala")
            {
                add = ";";
            }
            else
            {
                add = " WHERE fadn = '{0}' AND ano = '{1}';";
            }
            query = String.Format("SELECT idanalisis_puesto AS numero, YEAR(anio) AS anio, puesto_obtenido AS puesto, puntos AS punteo, " +
            "observacion " +
            "FROM pat_analisis_puesto INNER JOIN admin_anio ON idanio = fkanio" + add, fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}