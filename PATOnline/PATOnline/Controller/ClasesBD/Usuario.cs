using MySql.Data.MySqlClient;
using System;

namespace PATOnline.Controller.ClasesBD
{
    public class Usuario
    {
        public string query = "";
        public int idUsuario(string usuario)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * FROM seg_usuario WHERE username = '{0}';", usuario);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idusuario")))
                    {
                        return int.Parse(buscar["idusuario"].ToString());
                    }
                }
            }
            mysql.CerrarConexion();
            return 0;
        }
    }
}