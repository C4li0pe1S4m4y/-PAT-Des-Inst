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
    public class ReadFodaBEstrategica
    {
        public string query = "";
        public string add = "";
        public DataTable FODABEstrategicaRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if (fadn == "Confederación Deportiva Autónoma de Guatemala")
            {
                add = ";";
            }
            else
            {
                add = " WHERE fadn = {0} AND ano = {1};";
            }
            query = String.Format("SELECT idfoda_bestrategica AS numero, fortaleza, oportunidad, debilidad, amenaza, " +
            "mision, vision, valor " +
            "FROM pat_foda_baestrategica" + add, fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}