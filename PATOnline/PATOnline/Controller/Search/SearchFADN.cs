using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System;

namespace PATOnline.Controller.Search
{
    public class SearchFADN
    {
        public string query = "";
        public bool FADNSearch(string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT nombre FROM dbsecretaria.sg_fadn WHERE nombre = '{0}';", nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public DataTable LgotipoSearch(string fadn)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT dbsecretaria.l.idlogotipo, dbsecretaria.l.logo, dbsecretaria.l.fkfadn " +
            "FROM dbsecretaria.sg_fadn fa " +
            "INNER JOIN dbsecretaria.sg_logotipo l ON dbsecretaria.l.fkfadn = dbsecretaria.fa.id_fand " +
            "WHERE dbsecretaria.fa.nombre = '{0}';", fadn);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}