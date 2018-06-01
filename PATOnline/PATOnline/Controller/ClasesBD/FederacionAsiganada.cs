using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PATOnline.Controller.ClasesBD
{
    public class FederacionAsiganada
    {
        public string query = "";
        public DataTable FederacionAsigandasRead(int idUsuario)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idasignar_fadn AS numero, nombre_fadn AS federacion FROM dbcdagpat.admin_asignar_fadn " +
            "WHERE fkusuario = '{0}'; ", idUsuario);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}