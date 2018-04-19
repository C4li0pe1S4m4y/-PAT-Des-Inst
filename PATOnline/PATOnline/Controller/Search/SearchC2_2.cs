using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Search
{
    public class SearchC2_2
    {
        public string query = "";
        public int codigo;
        public int CodigoC2_2(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_c2_2 " +
            "WHERE idc2_2 = (SELECT MAX(idc2_2) FROM pat_c2_2 WHERE fadn = '{0}' AND ano = '{1}'); ", fadn, ano);
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    codigo = int.Parse(reader["numero"].ToString());
                }
            }
            mysql.CerrarConexion();
            return codigo;
        }
    }
}