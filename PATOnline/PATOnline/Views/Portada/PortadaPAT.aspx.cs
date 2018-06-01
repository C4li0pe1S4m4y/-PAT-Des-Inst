using System;
using PATOnline.Controller.Search;

namespace PATOnline.Views.Portada
{
    public partial class PortadaPAT : System.Web.UI.Page
    {
        SearchFederacion nomfe = new SearchFederacion();
        SearchLogotipo log = new SearchLogotipo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            CargarNombreFederacion();
            CargarLogotipoFederacion();
            lblAnio.Text = Convert.ToString(DateTime.Now.Year);
        }

        public void CargarNombreFederacion()
        {
            lblFederacion.Text = nomfe.NombreFederacion(Convert.ToString(Session["Usuario"]));

        }

        public void CargarLogotipoFederacion()
        {
            Imagelogo.ImageUrl = log.LogotipoFederacion(lblFederacion.Text);
        }
    }
}