using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MySql.Data.MySqlClient;
using PATOnline.DBConnection;
using PATOnline.Controller.Search;

namespace PATOnline.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        public int rol;
        string Titulo = "SISTEMA PAT";
        LoginUsuario usuario_password = new LoginUsuario();
        SearchRol buscar = new SearchRol();
        protected void Page_Load(object sender, EventArgs e)
        {   
            lblTitulo.Text = Titulo;
        }
        protected void Ingresar_Click(object sender, EventArgs e)
        {
            if (usuario_password.LoginUser(TxtUser.Text) == true)
            {
                if(usuario_password.LoginPassword(TxtUser.Text, TxtPass.Text) == true)
                {
                    this.Session["Usuario"] = this.TxtUser.Text;
                    rol = int.Parse(buscar.NombreRol(TxtUser.Text));

                    FormsAuthentication.RedirectFromLoginPage(this.TxtUser.Text, false);

                    if(rol == 1)
                    {
                        Response.Redirect("~/DashboardAdmin.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/DashboardFADN.aspx");
                    }
                    
                }
                else
                {
                    Response.Write("<script>window.alert('Password Incorrecto'" +
                    ",'Login')</script>");
                }
            }
            else
            {
                Response.Write("<script>window.alert('Usuario Incorrecto'" +
                ",'Login')</script>");
            }
        }
    }
}