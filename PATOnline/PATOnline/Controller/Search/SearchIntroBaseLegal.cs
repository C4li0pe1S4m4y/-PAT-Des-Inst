using MySql.Data.MySqlClient;
using System;

namespace PATOnline.Controller.Search
{
    public class SearchIntroBaseLegal
    {
        public string query = "";
        public int IntroBaseLegalSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_informacion " +
                "WHERE idinformacion = '{0}'", id);
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