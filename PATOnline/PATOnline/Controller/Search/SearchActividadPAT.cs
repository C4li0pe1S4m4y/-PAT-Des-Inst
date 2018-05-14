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
    public class SearchActividadPAT
    {
        public string query = "";
        public bool ExisteActividadPAT(int id, string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idactividad_pat FROM admin_actividad_pat WHERE idpadre='{0}' AND nombre='{1}';", id, nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idactividad_pat")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }
    }
}