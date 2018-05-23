using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using PATOnline.DBConnection;
using PATOnline.Controller.Search;

namespace PATOnline
{
    public partial class DashboardAdmin : System.Web.UI.Page
    {
        ConexionMysql mysql = new ConexionMysql();
        protected void Page_Load(object sender, EventArgs e)
        {
            CantidadUsuarios();
            CargarNombreFederacion();
            CargarLogotipoFederacion();
        }
        public void CantidadUsuarios()
        {
            mysql.AbrirConexion();
            string query = "SELECT COUNT(idusuario) AS cantidad FROM seg_usuario;";

            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lblContUsuario.Text = reader["cantidad"].ToString();
            }
            mysql.CerrarConexion();

            mysql.AbrirConexion();
            string query1 = "SELECT COUNT(idusuario) AS cantidad FROM seg_usuario WHERE fkestado = 1;";

            MySqlCommand cmd1 = new MySqlCommand(query1, mysql.conectar);
            MySqlDataReader reader1 = cmd1.ExecuteReader();

            if (reader1.Read())
            {
                lblUsuarioActivo.Text = reader1["cantidad"].ToString();
            }
            mysql.CerrarConexion();

            mysql.AbrirConexion();
            string query2 = "SELECT COUNT(idusuario) AS cantidad FROM seg_usuario WHERE fkestado = 2;";

            MySqlCommand cmd2 = new MySqlCommand(query2, mysql.conectar);
            MySqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.Read())
            {
                lblUsuarioInactivo.Text = reader2["cantidad"].ToString();
            }
            mysql.CerrarConexion();
        }

        public void CargarNombreFederacion()
        {
            SearchFederacion buscar = new SearchFederacion();
            lblFADN.Text = Convert.ToString(buscar.NombreFederacion(Convert.ToString(this.Session["Usuario"])));
        }

        public void CargarLogotipoFederacion()
        {
            SearchLogotipo buscar = new SearchLogotipo();
            logo.ImageUrl = Convert.ToString(buscar.LogotipoFederacion(lblFADN.Text));
        }
    }
}