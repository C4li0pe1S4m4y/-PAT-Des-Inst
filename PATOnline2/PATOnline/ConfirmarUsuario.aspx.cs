using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.Search;
using PATOnline.DBConnection;
using MySql.Data.MySqlClient;

namespace PATOnline
{
    public partial class ConfirmarUsuario : System.Web.UI.Page
    {
        SerachUsuario email = new SerachUsuario();
        ConexionMysql mysql = new ConexionMysql();
        public string chivo = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (email.BuscarCorreo(TxtEmail.Text) == true)
                {
                    mysql.AbrirConexion();
                    string query = "SELECT u.username as usuario " +
                    "FROM seg_usuario u " +
                    "WHERE u.correo_electronico = @correo AND u.verificar = AES_ENCRYPT(@Token, 'SCOGA');";

                    MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);

                    cmd.Parameters.AddWithValue("@correo", TxtEmail.Text);
                    cmd.Parameters.AddWithValue("@Token", TxtToken.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        this.Session["Usuario"] = reader["usuario"].ToString();
                        chivo = reader["usuario"].ToString();
                    }
                    mysql.CerrarConexion();
                    Response.Redirect("Reset.aspx");
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Error Verifique la información','Error')</script>");
            }
        }
    }
}