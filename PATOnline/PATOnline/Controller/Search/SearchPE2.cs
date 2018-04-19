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
    public class SearchPE2
    {
        public string query = "";
        public int codigo;
        public double presupuesto;
        public int CodigoPE1(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_pe2 " +
            "WHERE idpe2 = (SELECT MAX(idpe2) FROM pat_pe2 WHERE fadn = '{0}' AND ano = '{1}'); ", fadn, ano);
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

        public double PresupuestoPE2(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_cpe cpe " +
            "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
            "WHERE cpe.fadn = '{0}' AND cpe.ano = '{0}' AND f.nombre = 'PE2. Actividades Generales Presupuestadas';", fadn, ano);
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    presupuesto = double.Parse(reader["numero"].ToString());
                }
            }
            mysql.CerrarConexion();
            return presupuesto = 0;
        }

        public double PE2Total(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT SUM(p.presupuesto) AS total " +
            "FROM pat_pe2 p WHERE fadn = '{0}' AND ano = '{1}';", fadn, ano);
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    presupuesto = double.Parse(reader["total"].ToString());
                }
            }
            mysql.CerrarConexion();
            return presupuesto;
        }
    }
}