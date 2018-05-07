using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadResultado
    {
        public string query = "";
        public string add = "";
        public DataTable ResultadoRead(string fadn, string ano)
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
            query = String.Format("SELECT r.idresultado_dih AS numero, n.nombre AS nivel, r.nombre AS competencia, " +
            "r.sede AS sed, CONCAT(DAY(r.fecha), '/', MONTH(r.fecha), '/', YEAR(r.fecha)) AS fecha_resultado, " +
            "c.nombre AS categoria, r.resultado AS resultado_obtenido, r.observacion AS observar " +
            "FROM pat_resultado_dih r " +
            "INNER JOIN admin_nivel n ON n.idnivel = r.fknivel " +
            "INNER JOIN admin_categoria c ON c.idcategoria = r.fkcategoria" + add, fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}