using System;
using System.Web.Security;
using PATOnline.Controller.Search;
using PATOnline.Controller.Read;
using System.Data;

namespace PATOnline.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        public int rol;
        string Titulo = "SISTEMA PAT";
        LoginUsuario usuario_password = new LoginUsuario();
        SearchRol buscar = new SearchRol();
        SearchFederacion federacion = new SearchFederacion();
        ReadRolPermiso rool = new ReadRolPermiso();
        protected void Page_Load(object sender, EventArgs e)
        {   
            lblTitulo.Text = Titulo;
        }
        protected void Ingresar_Click(object sender, EventArgs e)
        {
            if (usuario_password.LoginUser(TxtUser.Text) == true)
            {
                if (usuario_password.LoginPassword(TxtUser.Text, TxtPass.Text) == true)
                {
                    this.Session["Usuario"] = this.TxtUser.Text;
                    this.Session["Federacion"] = federacion.NombreFederacion(TxtUser.Text);
                    rol = int.Parse(buscar.NombreRol(TxtUser.Text));


                    DataTable data = new DataTable();
                    data = rool.RolReadUsuario(TxtUser.Text);

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        this.Session["Rol"] = data.Rows[i][0].ToString();
                    }

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