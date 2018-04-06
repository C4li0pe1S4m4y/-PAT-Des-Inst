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
    public class ReadIBL
    {
        public string query = "";
        public string add = "";
        public DataTable IBLRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(fadn == "Confederación Deportiva Autónoma de Guatemala")
            {
                add = ";";
            }
            else
            {
                add = " WHERE fadn = {0} AND ano = {1};";
            }
            query = String.Format("SELECT idinformacion as numero, introduccion as introduccion, marco_juridico as marco, afiliacion_organizacion as afiliacion " +
            "FROM pat_informacion" + add, fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}