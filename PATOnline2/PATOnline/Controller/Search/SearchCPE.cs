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
    public class SearchCPE
    {
        public string query = "";
        public double total_p1;
        public double total_p3;
        public bool ExisteCPE(int id, string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT fkformato_c FROM pat_cpe WHERE fkformato_c = '{0}' AND ano = '{1}' AND fadn = '{2}';", id, anio, fadn);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("fkformato_c")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public double VerificarMontoP1(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT p1.col_uno AS total_p1 FROM pat_p1 p1 INNER JOIN admin_ingreso_corriente ic " + 
            "ON ic.idingreso_corriente = p1.fkingreso_corriente " +
            "WHERE ic.fadn = '{0}' AND ic.nombre = 'De Gobierno Central (Aprobado en Asamblea de CDAG)' " +
            "AND p1.fadn = '{0}' AND p1.ano = '{1}'; ", fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    total_p1 = Convert.ToDouble(buscar["total_p1"].ToString());
                }
            }
            mysql.CerrarConexion();
            return total_p1;
        }

        public double VerificarMontoP3(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT SUM(p3.total) AS total_p3 FROM pat_p3 p3 " +
            "WHERE p3.fadn = '{0}' AND p3.ano = '{1}'; ", fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    total_p3 = Convert.ToDouble(buscar["total_p3"].ToString());
                }
            }
            mysql.CerrarConexion();
            return total_p3;
        }

        public double MontoP1_Igual_P3(string fadn, string anio)
        {
            double monto = VerificarMontoP1(fadn, anio) - VerificarMontoP3(fadn, anio);
            return monto;
        }
    }
}