using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadFormatoC
    {
        public string query = "";
        public string opcion;
        public DataTable FormatoCRead(int id, string tipoid)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            switch (tipoid)
            {
                case "idformato_c": opcion = "  WHERE idformato_c='{0}';";
                    break;
                case "idpadre": opcion = "  WHERE idpadre='{0}';";
                    break;
            }
            query = String.Format("SELECT idformato_c, nombre FROM admin_formato_c"+ opcion, id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}