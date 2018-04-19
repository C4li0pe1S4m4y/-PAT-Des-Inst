using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadPontencia
    {
        public string query = "";
        public string add = "";
        public DataTable PotenciaRead(string fadn, string ano)
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
            query = String.Format("SELECT p.idpotencia_ag AS numero, n.nombre AS nivel, p.primera_potencia AS primera, " +
            "p.segunda_potencia AS segunda, p.tercera_potencia AS tercera, p.posicion_guatemala AS posicion " +
            "FROM pat_potencia_ag p " +
            "INNER JOIN admin_nivel n ON n.idnivel = p.fknivel" + add, fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}