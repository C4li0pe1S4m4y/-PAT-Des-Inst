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
    public class SearchPE1
    {
        public string query = "";
        public int codigo;
        public int CodigoPE1(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_pe1 " +
            "WHERE idpe1 = (SELECT MAX(idpe1) FROM pat_pe1 WHERE fadn = '{0}' AND ano = '{1}'); ", fadn, ano);
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