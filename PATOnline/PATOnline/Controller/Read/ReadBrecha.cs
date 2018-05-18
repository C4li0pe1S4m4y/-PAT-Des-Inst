using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Read
{
    public class ReadBrecha
    {
        public string query = "";
        public string add = "";
        public DataTable BrechaRead(string fadn, string ano)
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
            query = String.Format("SELECT nombre AS brecha, puntos AS punteo, puntos_obtenidos AS punteo_obtenido, " +
            "comparacion, observacion, idanalisis_brecha AS numero " +
            "FROM pat_analisis_brecha " +
            "INNER JOIN admin_brecha ON idbrecha = fkbrecha" + add, fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}