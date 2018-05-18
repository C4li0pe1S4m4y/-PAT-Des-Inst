using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace PATOnline.DBConnection
{
    public class ConexionMysql
    {
        private String contenido1 = "server=localhost;user=root;database=dbcdagpat;password=root";
        private String contenido = "server=localhost; database =dbcdagpat;user=usr_cdag_sipa; password =5sr_cd1g_s3pa";
        public MySqlConnection conectar = new MySqlConnection();
        public MySqlDataAdapter adaptador = new MySqlDataAdapter();
        public DataTable tabla = new DataTable();

        public void AbrirConexion()
        {
            string sConn;
            sConn = contenido;
            conectar = new MySqlConnection();
            conectar.ConnectionString = sConn;

            try
            {
                conectar.Open();
                Console.WriteLine("Conexión Exitosa");
            }
            catch (Exception ex)
            {
                string sConn2;
                sConn2 = contenido1;
                conectar = new MySqlConnection();
                conectar.ConnectionString = sConn2;
                Console.WriteLine(ex + "Probar Otra Conexion");
                try
                {
                    conectar.Open();
                    Console.WriteLine("Conexión Exitosa");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + "Fallo Conexión");
                }
            }
        }

        public void CerrarConexion()
        {
            if (conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}