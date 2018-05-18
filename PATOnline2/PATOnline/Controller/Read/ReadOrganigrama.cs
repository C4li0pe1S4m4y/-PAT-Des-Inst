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
    public class ReadOrganigrama
    {
        public string query = "";
        public string add = "";
        public DataTable OrgranigramaRead(string fadn, string ano)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            add = " WHERE fadn = '{0}' AND ano = '{1}';";
            
            query = String.Format("SELECT idorganigrama as numero, organigrama as organigrama " +
            "FROM pat_organigrama" + add, fadn, ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}