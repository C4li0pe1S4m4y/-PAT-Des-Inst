using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.Update;
using PATOnline.Models;
using System.Text;

namespace PATOnline
{
    public partial class Reset : System.Web.UI.Page
    {
        UpdateResetPassword reset = new UpdateResetPassword();
        ModeloUsuario modelo = new ModeloUsuario();
        public string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@!/#*";
        public string verificar;
        public int contador = 6;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblUser.Text = this.Session["Usuario"].ToString();
                TxtPassword.Text = null;
                TxtConfirPassword.Text = null;
            }
            catch
            {
                Response.Redirect("ConfirmarUsuario.aspx");
            }
            
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            verificar = "CDAG-" + toke();
            modelo.password = TxtPassword.Text;
            modelo.user = lblUser.Text;
            modelo.verifica = verificar;
            try
            {
                reset.PasswordReset(modelo);
                Response.Redirect("~/Login.aspx");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear Password','Crear Password')" +
                ";</script>" + "<script>window.setTimeout(location.href='Login.aspx', 1);</script>");
            }
        }

        public string toke()
        {
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < contador--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }
    }
}